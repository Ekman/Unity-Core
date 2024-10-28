using UnityEngine;

namespace Nekman.Core.Extensions
{
    public static class Vector2Extension
    {
        public static Vector2 SetX(this Vector2 v, float x) => new(x, v.y);
        public static Vector2 SetY(this Vector2 v, float y) => new(v.x, y);
        public static Vector3 XY(this Vector3 v) => new(v.x, v.y, 0);
        public static Vector3 XZ(this Vector3 v) => new(v.x, 0, v.y);
        public static Vector3 YX(this Vector3 v) => new(v.y, v.x, 0);
        public static Vector3 YZ(this Vector3 v) => new(0, v.y v.x);
        public static Vector3 ZX(this Vector3 v) => new(v.y, 0, v.x);
        public static Vector3 ZY(this Vector3 v) => new(0, v.x, v.y);
    }
}
