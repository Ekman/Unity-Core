using System;
using System.IO;
using System.Threading;
using UnityEditor;

namespace Nekman.Core.Editor.Utilities
{
    public static class BuildUtility
    {
        public static void SetVersion(string version, Action callback)
        {
            // Remember this and set it back to the original . Else, we'll
            // get updates in Git which can be annoying.
            var originalBundleVersion = PlayerSettings.bundleVersion;

            try
            {
                PlayerSettings.bundleVersion = version;
                
                callback();
            }
            finally
            {
                PlayerSettings.bundleVersion = originalBundleVersion;
            }
        }

        public static string CreateBinaryFilenamePath(string outputPath, string platformName, string binaryName)
        {
            var binaryFilenamePath = Path.Combine(outputPath, platformName);
                
            if (!string.IsNullOrWhiteSpace(binaryName))
            {
                binaryFilenamePath = Path.Combine(binaryFilenamePath, binaryName);
            }

            return binaryFilenamePath;
        }
    }
}
