using System;
using UnityEditor;
using UnityEditor.Build;

namespace Nekman.Core.Editor.Platforms
{
    public class Linux : IPlatform
    {
        public string Name => nameof(Linux);

        public OSArchitecture? Architecture => OSArchitecture.x64;

        public BuildTarget BuildTarget => BuildTarget.StandaloneLinux64;
        
        public BuildTargetGroup BuildTargetGroup => BuildTargetGroup.Standalone;

        public string CreateBinaryFilename(string projectName) => $"{projectName}.x86_64";
    }
}
