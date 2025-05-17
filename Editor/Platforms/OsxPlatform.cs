using UnityEditor;
using UnityEditor.Build;

namespace Nekman.Core.Editor.Platforms
{
    public abstract class OsxPlatform : IPlatform
    {
        public abstract string Name { get; }
        
        public abstract OSArchitecture? Architecture { get; }
        
        public BuildTarget BuildTarget => BuildTarget.StandaloneOSX;
        
        public BuildTargetGroup BuildTargetGroup => BuildTargetGroup.Standalone;
        
        public string CreateBinaryFilename(string projectName) => $"{projectName}.app";
    }
}
