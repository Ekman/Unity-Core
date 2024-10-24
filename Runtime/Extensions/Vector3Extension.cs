using UnityEngine;

namespace Nekman.Core.Extensions
{
    public static class Vector3Extension
    {
        public static Vector3 SetX(this Vector3 v, float x) => new(x, v.y, v.z);
        public static Vector3 SetY(this Vector3 v, float y) => new(v.x, y, v.z);
        public static Vector3 SetZ(this Vector3 v, float z) => new(v.x, v.y, z);
        public static Vector3 SetXY(this Vector3 v, float x, float y) => new(x, y, v.z);
        public static Vector3 SetXZ(this Vector3 v, float x, float z) => new(x, v.y, z);
        public static Vector3 SetYZ(this Vector3 v, float y, float z) => new(v.x, y, z);
    }
}
