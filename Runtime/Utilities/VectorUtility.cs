using UnityEngine;

namespace Nekman.Core.Utilities
{
    public static class VectorUtility
    {
        public static Vector3 GetDirectionTo(Vector3 origin, Vector3 target) => (target - origin).normalized;
    }
}
