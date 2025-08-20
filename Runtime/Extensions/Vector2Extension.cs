using UnityEngine;

namespace Nekman.Core.Extensions
{
    public static class Vector2Extension
    {
        public static Vector2 SetX(this Vector2 vector, float x) => new(x, vector.y);
        public static Vector2 SetY(this Vector2 vector, float y) => new(vector.x, y);
        public static Vector3 XY(this Vector3 vector, float z = 0) => new(vector.x, vector.y, z);
        public static Vector3 XZ(this Vector3 vector, float y = 0) => new(vector.x, y, vector.y);
        public static Vector3 YX(this Vector3 vector, float z = 0) => new(vector.y, vector.x, z);
        public static Vector3 YZ(this Vector3 vector, float x = 0) => new(x, vector.y, vector.x);
        public static Vector3 ZX(this Vector3 vector, float y = 0) => new(vector.y, y, vector.x);
        public static Vector3 ZY(this Vector3 vector, float x = 0) => new(x, vector.x, vector.y);
    }
}
