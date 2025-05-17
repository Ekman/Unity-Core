using System;
using Nekman.Core.Editor.Platforms;
using System.IO;
using System.Linq;
using System.Threading;
using Nekman.Core.Editor.Utilities;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.WebGL;
using UnityEngine;

namespace Nekman.Core.Editor
{
    public static class Build
    {
        public static int Windows() => BuildPlatform<Windows>();

        public static int Linux() => BuildPlatform<Linux>();

        public static int OsxIntel() => BuildPlatform<OsxIntel>();

        public static int OsxSilicon() => BuildPlatform<OsxSilicon>();
        
        public static int WebGl() => BuildPlatform<WebGl>();

        private static int BuildPlatform<T>() where T : IPlatform, new()
        {
            var buildConfig = BuildConfig.CreateThrowIfInvalid();
            
            return BuildUtility.SetVersion(buildConfig.Version, () =>
            {
                var platform = new T();

                if (!EditorUserBuildSettings.SwitchActiveBuildTarget(platform.BuildTargetGroup, platform.BuildTarget))
                {
                    throw new BuildException("Could not switch active build target.");
                }
                
                // Switching platform can take a while.
                Thread.Sleep(TimeSpan.FromSeconds(5));

#if UNITY_WEBGL
                Debug.Log("Building WebGL");
                UnityEditor.WebGL.UserBuildSettings.codeOptimization = WasmCodeOptimization.RuntimeSpeedLTO;
#elif UNITY_EDITOR_WIN
                Debug.Log("Building Windows");
                UnityEditor.WindowsStandalone.UserBuildSettings.architecture = platform.Architecture ?? throw new ArgumentNullException(nameof(platform.Architecture), "Architecture can't be null");
                UnityEditor.WindowsStandalone.UserBuildSettings.copyPDBFiles = false;
#elif UNITY_EDITOR_OSX
                Debug.Log("Building OSX");
                UnityEditor.OSXStandalone.UserBuildSettings.architecture = platform.Architecture ?? throw new ArgumentNullException(nameof(platform.Architecture), "Architecture can't be null");;
#endif

                var productName = PlayerSettings.productName.Replace(" ", string.Empty);
                var binaryName = $"{productName}.{platform.BinaryExtension}";

                var buildPlayerOptions = new BuildPlayerOptions
                {
                    locationPathName = Path.Combine(buildConfig.OutputPath, platform.Name, binaryName),
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
                    return -1;
                }

                Debug.Log($"Build \"{platform.Name}\" successful.");
                return 0; 
            });
        }
    }
}
