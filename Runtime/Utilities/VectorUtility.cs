using UnityEngine;

namespace Nekman.Core.Utilities
{
    public static class VectorUtility
    {
        public static Vector3 GetDirectionTo(Vector3 origin, Vector3 target) => (target - origin).normalized;
        
        /// <summary>
        /// Calculate where an attack would land, given a point of attack and direction and max distance.
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="maxDistance"></param>
        /// <returns></returns>
        public static Vector3 GetHitPoint(Vector3 attackDirection, float maxDistance) => attack.position + attack.position.normalized * maxDistance;
    }
}
