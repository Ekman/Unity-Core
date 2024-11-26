using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nekman.Core.Utilities
{
    public static class LayerMaskUtility
    {
        public static int Combine(IEnumerable<LayerMask> layerMasks)
            => layerMasks
                .Select(layerMask => layerMask.value)
                .Aggregate(
                    0,
                    (combinedMask, layerMask) => combinedMask | layerMask
                );
    }
}
