using UnityEditor;
using UnityEditor.Build;

namespace Editor.Platforms
{
    public readonly struct OsxIntel : IPlatform
    {
        public string Name => nameof(OsxIntel);

        public OSArchitecture Architecture => OSArchitecture.x64;

        public BuildTarget BuildTarget => BuildTarget.StandaloneOSX;

        public string BinaryExtension => "app";
    }
}
