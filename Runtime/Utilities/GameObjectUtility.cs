using System;
using UnityEngine;

namespace Nekman.Core.Utilities
{
    public static class GameObjectUtility
    {
        public static Size GetColliderSize(GameObject gameObject)
        {
            var collider = gameObject.GetComponent<Collider>();

            if (!collider)
            {
                throw new ArgumentException($"{nameof(GameObject)} must have a {nameof(Collider)}.");
            }

            return BoundsToSize(collider.bounds);
        }

        private static Size BoundsToSize(Bounds bounds) => new Size(bounds.min.x, bounds.max.y);
    }
}
