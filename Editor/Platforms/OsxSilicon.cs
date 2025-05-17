using UnityEditor;
using UnityEditor.Build;

namespace Nekman.Core.Editor.Platforms
{
    public class OsxSilicon : OsxPlatform
    {
        public override string Name => nameof(OsxSilicon);

        public override OSArchitecture? Architecture => OSArchitecture.ARM64;
    }
}
