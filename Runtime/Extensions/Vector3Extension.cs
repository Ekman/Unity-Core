using UnityEngine;

namespace Nekman.Core.Extensions
{
    public static class Vector3Extension
    {
        public static Vector3 SetX(this Vector3 vector, float x) => new(x, vector.y, vector.z);
        public static Vector3 SetY(this Vector3 vector, float y) => new(vector.x, y, vector.z);
        public static Vector3 SetZ(this Vector3 vector, float z) => new(vector.x, vector.y, z);
        public static Vector3 SetXY(this Vector3 vector, float x, float y) => new(x, y, vector.z);
        public static Vector3 SetXY(this Vector3 vector, float v) => new(v, v, vector.z);
        public static Vector3 SetXZ(this Vector3 vector, float x, float z) => new(x, vector.y, z);
        public static Vector3 SetXZ(this Vector3 vector, float v) => new(v, vector.y, v);
        public static Vector3 SetYZ(this Vector3 vector, float y, float z) => new(vector.x, y, z);
        public static Vector3 SetYZ(this Vector3 vector, float v) => new(vector.x, v, v);
        public static Vector2 XY(this Vector3 vector) => new(vector.x, vector.y);
        public static Vector2 XZ(this Vector3 vector) => new(vector.x, vector.z);
        public static Vector2 XX(this Vector3 vector) => new(vector.x, vector.x);
        public static Vector2 YX(this Vector3 vector) => new(vector.y, vector.x);
        public static Vector2 YZ(this Vector3 vector) => new(vector.y, vector.z);
        public static Vector2 YY(this Vector3 vector) => new(vector.y, vector.y);
        public static Vector2 ZX(this Vector3 vector) => new(vector.z, vector.x);
        public static Vector2 ZY(this Vector3 vector) => new(vector.z, vector.y);
        public static Vector2 ZZ(this Vector3 vector) => new(vector.z, vector.z);
    }
}
