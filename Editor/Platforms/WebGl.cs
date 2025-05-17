using UnityEditor;
using UnityEditor.Build;

namespace Nekman.Core.Editor.Platforms
{
    public readonly struct WebGl : IPlatform
    {
        public string Name => nameof(WebGl);

        public OSArchitecture? Architecture => null;

        public BuildTarget BuildTarget => BuildTarget.WebGL;

        public string BinaryExtension => "html";
        
        public BuildTargetGroup BuildTargetGroup => BuildTargetGroup.WebGL;
    }
}
