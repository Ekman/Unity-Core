using UnityEditor;
using UnityEditor.Build;

namespace Editor.Platforms
{
    public readonly struct Windows : IPlatform
    {
        public string Name => nameof(Windows);

        public OSArchitecture Architecture => OSArchitecture.x64;

        public BuildTarget BuildTarget => BuildTarget.StandaloneWindows64;

        public string BinaryExtension => "exe";
    }
}
