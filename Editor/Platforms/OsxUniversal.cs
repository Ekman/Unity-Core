using UnityEditor;
using UnityEditor.Build;

namespace Nekman.Core.Editor.Platforms
{
    public class OsxUniversal : OsxPlatform
    {
        public override string Name => nameof(OsxUniversal);

        public override OSArchitecture? Architecture => OSArchitecture.x64ARM64;
    }
}
