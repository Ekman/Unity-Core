using UnityEditor;

namespace Nekman.Core.Editor
{
    public static class PreBuild
    {
        public static void Run()
        {
            Lightmapping.Bake();
            StaticOcclusionCulling.GenerateInBackground();
        }
    }
}
