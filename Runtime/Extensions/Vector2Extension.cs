using UnityEngine;

namespace Nekman.Core.Extensions
{
    public static class Vector2Extension
    {
        public static Vector2 SetX(this Vector2 v, float x) => new(x, v.y);
        public static Vector2 SetY(this Vector2 v, float y) => new(v.x, y);
        public static Vector3 XY(this Vector3 v, float z = 0) => new(v.x, v.y, z);
        public static Vector3 XZ(this Vector3 v, float y = 0) => new(v.x, y, v.y);
        public static Vector3 YX(this Vector3 v, float z = 0) => new(v.y, v.x, z);
        public static Vector3 YZ(this Vector3 v, float x = 0) => new(x, v.y v.x);
        public static Vector3 ZX(this Vector3 v, float y = 0) => new(v.y, y, v.x);
        public static Vector3 ZY(this Vector3 v, float x = 0) => new(x, v.x, v.y);
    }
}
