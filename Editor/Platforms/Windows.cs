using UnityEditor;
using UnityEditor.Build;

namespace Nekman.Core.Editor.Platforms
{
    public class Windows : IPlatform
    {
        public string Name => nameof(Windows);

        public OSArchitecture? Architecture => OSArchitecture.x64;

        public BuildTarget BuildTarget => BuildTarget.StandaloneWindows64;
        
        public BuildTargetGroup BuildTargetGroup => BuildTargetGroup.Standalone;
        
        public string CreateBinaryFilename(string projectName) => $"{projectName}.exe";
        
    }
}
