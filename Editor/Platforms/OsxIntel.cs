using UnityEditor;
using UnityEditor.Build;

namespace Nekman.Core.Editor.Platforms
{
    public class OsxIntel : OsxPlatform
    {
        public override string Name => nameof(OsxIntel);

        public override  OSArchitecture? Architecture => OSArchitecture.x64;
    }
}
