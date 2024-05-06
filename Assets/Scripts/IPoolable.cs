
using System;
using UnityEngine;

namespace Pool
{
    public interface IPoolable
    {
        public PoolObjectType poolObjectType { get ; set; }
        void Initialize(Transform parent = null);
        void ResetObject(Transform parent = null);

    }
}