using UnityEngine;

namespace Nekman.Core
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        public void Awake()
        {
            if (!Instance)
            {
                Instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
