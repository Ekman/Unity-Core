using UnityEngine;

namespace Nekman.Core.Utilities
{
    public class AttackUtility
    {
        /// <summary>
        /// Calculate where an attack would land, given a point of attack and direction and max distance.
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="maxDistance"></param>
        /// <returns></returns>
        public static Vector3 GetHitPoint(Transform attack, float maxDistance) => attack.position + attack.forward.normalized * maxDistance;   
    }
}
