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
        public static Vector2 XY(this Vector3 v) => new(v.x, v.y);
        public static Vector2 XZ(this Vector3 v) => new(v.x, v.z);
        public static Vector2 XX(this Vector3 v) => new(v.x, v.x);
        public static Vector2 YX(this Vector3 v) => new(v.y, v.x);
        public static Vector2 YZ(this Vector3 v) => new(v.y, v.z);
        public static Vector2 YY(this Vector3 v) => new(v.y, v.y);
        public static Vector2 ZX(this Vector3 v) => new(v.z, v.x);
        public static Vector2 ZY(this Vector3 v) => new(v.z, v.y);
        public static Vector2 ZZ(this Vector3 v) => new(v.z, v.z)
    }
}
