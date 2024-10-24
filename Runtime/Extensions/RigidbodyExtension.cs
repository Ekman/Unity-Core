using UnityEngine;

namespace Nekman.Core.Extensions
{
    public static class RigidbodyExtension
    {
        public static void LookRotation(this Rigidbody body, Vector3 forward, Vector3 up) 
            => body.MoveRotation(
                Quaternion.LookRotation(forward, up)
            );

        public static void LookRotation(this Rigidbody body, Vector3 forward)
            => LookRotation(body, forward, Vector3.up);
    }
}
