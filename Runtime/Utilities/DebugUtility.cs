using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Nekman.Core.Utilities {
    public static class DebugUtility {
        [Conditional("UNITY_EDITOR")]
        public static void DrawRayAllDirections(Vector3 start, Color color) {
            var allDirections = new Vector3[] {
                Vector3.up,
                Vector3.down,
                Vector3.left,
                Vector3.right,
                Vector3.forward,
                Vector3.back,
            };

            foreach (var direction in allDirections) {
                Debug.DrawRay(start, direction, color);   
            }
        }
    }
}
