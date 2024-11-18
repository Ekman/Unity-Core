using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nekman.Core.Utilities
{
    public static class CircleUtility
    {
        public static IEnumerable<Vector3> RandomEvenlyDistributedPoints(int nPoints, float radius)
        {
            var angleIncrement = 360f / nPoints;  // Evenly spaced angle
            var randomOffset = Random.Range(0f, 360f);  // Randomize starting angle

            for (var i = 0; i < nPoints; i++)
            {
                var angle = randomOffset + i * angleIncrement;
                var radian = Mathf.Deg2Rad * angle;

                // Calculate point on the circle
                var x = Mathf.Cos(radian) * radius;
                var z = Mathf.Sin(radian) * radius;

                yield return new(x, 0, z);
            }
        }
        
        public static IEnumerable<Vector3> RandomEvenlyDistributedPointsAroundOrigin(int nPoints, float radius, Vector3 origin)
        {
            var points = RandomEvenlyDistributedPoints(nPoints, radius);

            return points.Select(point => origin + point);
        }
    }
}
