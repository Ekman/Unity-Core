using Nekman.Core.Editor.Platforms;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Nekman.Core.Editor
{
    public static class Build
    {
        public static int Windows() => BuildPlatform<Windows>();

        public static int Linux() => BuildPlatform<Linux>();

        public static int OsxIntel() => BuildPlatform<OsxIntel>();

        public static int OsxSilicon() => BuildPlatform<OsxSilicon>();

        private static int BuildPlatform<T>() where T : IPlatform, new()
        {
            var buildConfig = BuildConfig.CreateThrowIfInvalid();

            // Remember this and set it back to the original . Else, we'll
            // get updates in Git which can be annoying.
            var originalBundleVersion = PlayerSettings.bundleVersion;

            try
            {
                var platform = new T();

                PlayerSettings.bundleVersion = buildConfig.Version;

#if UNITY_EDITOR_WIN
                UnityEditor.WindowsStandalone.UserBuildSettings.architecture = platform.Architecture;
                UnityEditor.WindowsStandalone.UserBuildSettings.copyPDBFiles = false;
#elif UNITY_EDITOR_OSX
                UnityEditor.OSXStandalone.UserBuildSettings.architecture = platform.Architecture;
#endif

                var productName = PlayerSettings.productName.Replace(" ", string.Empty);
                var binaryName = $"{productName}.{platform.BinaryExtension}";

                var buildPlayerOptions = new BuildPlayerOptions()
                {
                    locationPathName = Path.Combine(buildConfig.OutputPath, platform.Name, binaryName),
                    options = BuildOptions.StrictMode | BuildOptions.CompressWithLz4HC,
                    scenes = EditorBuildSettings.scenes
                        .Where(scene => scene.enabled)
                        .Select(scene => scene.path)
                        .ToArray(),
                    target = platform.BuildTarget,
                    targetGroup = BuildTargetGroup.Standalone,
                };

                var report = BuildPipeline.BuildPlayer(buildPlayerOptions);

                if (report.summary.result == BuildResult.Failed)
                {
                    Debug.LogError($"Build \"{platform.Name}\" failed, see logs.");
                    return -1;
                }

                Debug.Log($"Build \"{platform.Name}\" successful.");

                return 0;
            }
            finally
            {
                PlayerSettings.bundleVersion = originalBundleVersion;
            }
        }
    }
}
