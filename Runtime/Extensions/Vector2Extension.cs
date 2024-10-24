using UnityEngine;

namespace Nekman.Core.Extensions
{
    public static class Vector2Extension
    {
        public static Vector2 SetX(this Vector2 v, float x) => new(x, v.y);
        public static Vector2 SetY(this Vector2 v, float y) => new(v.x, y);
    }
}
