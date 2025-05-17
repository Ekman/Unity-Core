using UnityEditor;
using UnityEditor.Build;

namespace Nekman.Core.Editor.Platforms
{
    public class WebGl : IPlatform
    {
        public string Name => nameof(WebGl);

        public OSArchitecture? Architecture => null;

        public BuildTarget BuildTarget => BuildTarget.WebGL;
        
        public BuildTargetGroup BuildTargetGroup => BuildTargetGroup.WebGL;

        public string CreateBinaryFilename(string projectName) => null;
    }
}
