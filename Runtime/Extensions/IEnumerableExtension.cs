using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nekman.Core.Extensions
{
    public static class IEnumerableExtension
    {
        public static IOrderedEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
            => collection.OrderBy(_ => Random.Range(0, 1000));
    }
}
