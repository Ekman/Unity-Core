using UnityEditor;
using UnityEditor.Build;

namespace Nekman.Core.Editor.Platforms
{
    public readonly struct Linux : IPlatform
    {
        public string Name => nameof(Linux);

        public OSArchitecture Architecture => OSArchitecture.x64;

        public BuildTarget BuildTarget => BuildTarget.StandaloneLinux64;

        public string BinaryExtension => "x86_64";
    }
}
