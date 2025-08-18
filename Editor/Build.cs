using System;
using Nekman.Core.Editor.Platforms;
using System.IO;
using System.Linq;
using System.Threading;
using Nekman.Core.Editor.Utilities;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
#if UNITY_WEBGL
using UnityEditor.WebGL;
#endif

namespace Nekman.Core.Editor
{
    public static class Build
    {
        public static void Windows() => BuildPlatform<Windows>();

        public static void Linux() => BuildPlatform<Linux>();

        public static void OsxUniversal() => BuildPlatform<OsxUniversal>();

        public static void OsxIntel() => BuildPlatform<OsxIntel>();

        public static void OsxSilicon() => BuildPlatform<OsxSilicon>();
        
        public static void WebGl() => BuildPlatform<WebGl>();

        private static void BuildPlatform<T>() where T : IPlatform, new()
        {
            var platform = new T();
            var buildConfig = BuildConfig.CreateThrowIfInvalid();

            BuildUtility.SetVersion(buildConfig.Version, () =>
            {
#if UNITY_WEBGL
                Debug.Log("Building WebGL");
                UnityEditor.WebGL.UserBuildSettings.codeOptimization = WasmCodeOptimization.BuildTimes;
#elif UNITY_EDITOR_WIN
                Debug.Log("Building Windows");
                UnityEditor.WindowsStandalone.UserBuildSettings.architecture = platform.Architecture
                    ?? throw new ArgumentNullException(nameof(platform.Architecture), "Architecture can't be null");
                UnityEditor.WindowsStandalone.UserBuildSettings.copyPDBFiles = false;
#elif UNITY_EDITOR_OSX
                Debug.Log("Building OSX");
                UnityEditor.OSXStandalone.UserBuildSettings.architecture = platform.Architecture 
                    ?? throw new ArgumentNullException(nameof(platform.Architecture), "Architecture can't be null");
#endif

                var productName = PlayerSettings.productName.Replace(" ", string.Empty);
                var binaryName = platform.CreateBinaryFilename(productName);

                var buildPlayerOptions = new BuildPlayerOptions
                {
                    locationPathName = BuildUtility.CreateBinaryFilenamePath(buildConfig.OutputPath, platform.Name, binaryName),
                    options = BuildOptions.StrictMode | BuildOptions.CompressWithLz4HC,
                    scenes = EditorBuildSettings.scenes
                        .Where(scene => scene.enabled)
                        .Select(scene => scene.path)
                        .ToArray(),
                    target = platform.BuildTarget,
                    targetGroup = platform.BuildTargetGroup,
                };

                var report = BuildPipeline.BuildPlayer(buildPlayerOptions);
                
                if (report.summary.result == BuildResult.Failed)
                {
                    Debug.LogError($"Build \"{platform.Name}\" failed, see logs.");
                    Application.Quit(-1);
                    return;
                }

                Debug.Log($"Build \"{platform.Name}\" successful.");
            });
        }
    }
}
