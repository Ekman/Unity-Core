using UnityEditor;
using UnityEditor.Build;

namespace Nekman.Core.Editor.Platforms
{
    public interface IPlatform
    {
        public string Name { get; }
        // See: https://docs.unity3d.com/ScriptReference/Build.OSArchitecture.html
        public OSArchitecture? Architecture { get; }
        public BuildTarget BuildTarget { get; }
        public string BinaryExtension { get; }
        public BuildTargetGroup BuildTargetGroup { get; }
    }
}
