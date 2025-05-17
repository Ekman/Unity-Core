using System;
using System.IO;
using UnityEditor;

namespace Nekman.Core.Editor.Utilities
{
    public static class BuildUtility
    {
        public static int SetVersion(string version, Func<int> callback)
        {
            // Remember this and set it back to the original . Else, we'll
            // get updates in Git which can be annoying.
            var originalBundleVersion = PlayerSettings.bundleVersion;

            try
            {
                PlayerSettings.bundleVersion = version;
                
                return callback();
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
