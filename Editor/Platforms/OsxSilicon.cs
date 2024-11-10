using UnityEditor;
using UnityEditor.Build;

namespace Editor.Platforms
{
    public readonly struct OsxSilicon : IPlatform
    {
        public string Name => nameof(OsxSilicon);

        public OSArchitecture Architecture => OSArchitecture.ARM64;

        public BuildTarget BuildTarget => BuildTarget.StandaloneOSX;

        public string BinaryExtension => "app";
    }
}
