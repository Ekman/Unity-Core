using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace Nekman.Core.Editor
{
    public static class PreBuild
    {
        public static void Run()
        {
            Debug.Log("Building addressable.");
            AddressableAssetSettingsDefaultObject.Settings.ActivePlayerDataBuilder.ClearCachedData();
            AddressableAssetSettings.CleanPlayerContent();
            AddressableAssetSettings.BuildPlayerContent();
            
            Debug.Log("Baking lightning.");
            Lightmapping.Bake();
            
            Debug.Log("Baking occlussion culling.");
            StaticOcclusionCulling.GenerateInBackground();
        }
    }
}
