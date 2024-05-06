using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class PoolManager : Singleton<PoolManager>
    {
        [Header("Parents")]
        [SerializeField] private Transform pooledObjectParent;
        [SerializeField] private Transform ingameParent;

        [Header("Serialized Objects")]
        [SerializeField] private PoolObjects poolObjects;

        private readonly Dictionary<PoolObjectType, Pool> poolTypeTpPoolItemDictionary = new Dictionary<PoolObjectType, Pool>();

        
        protected override void Awake()
        {
            base.Awake();
            CreatePools();
        }

        private void CreatePools()
        {
            foreach (var poolObject in poolObjects.GetIPoolables())
            {
                var poolObjectType = poolObject.Key.poolObjectType;
                var pool = new Pool(poolObject.Key);
                poolTypeTpPoolItemDictionary.Add(poolObjectType, pool);

                if(poolObject.Value > 0)
                    CreateInitialSpawn(poolObjectType, poolObject.Value);
            }
        }

        private void CreateInitialSpawn(PoolObjectType poolObjectType, int numberToSpawn)
        {
            Stack<IPoolable> pooledObjectsTemp = new();
            for (int i = 0;i < numberToSpawn;i++)
                pooledObjectsTemp.Push(Get(poolObjectType));

            for (int i = 0;i < numberToSpawn;i++)
                Release(pooledObjectsTemp.Pop());
        }

        public IPoolable Get(PoolObjectType poolObjectType)
        {
            IPoolable poolable = poolTypeTpPoolItemDictionary[poolObjectType].Pop();
            poolable.Initialize(ingameParent);
            return poolable;
        }

        public void Release(IPoolable poolObject)
        {
            var pool = poolTypeTpPoolItemDictionary[poolObject.poolObjectType];
            poolObject.ResetObject(pooledObjectParent);
            pool.Push(poolObject);
        }

        //public void ResetPools()
        //{
        //    foreach (var poolTypeToPoolItem in poolTypeTpPoolItemDictionary)
        //    {
        //        poolTypeToPoolItem.Value.ResetObject();
        //    }
        //}
    }

    public class Pool
    {
        private readonly Stack<IPoolable> pooledObjects = new Stack<IPoolable>();
        //private readonly HashSet<IPoolable> activeObjects = new HashSet<IPoolable>();
        private readonly IPoolable prefab;

        private int PooledObjectCount => pooledObjects.Count;
        //private int ActiveObjectCount => activeObjects.Count;

        public Pool(IPoolable prefab)
        {
            this.prefab = prefab;
        }

        public IPoolable Pop()
        {
            IPoolable poolObject = PooledObjectCount > 0 ? pooledObjects.Pop() : (IPoolable)GameObject.Instantiate((UnityEngine.Object)prefab);
            //activeObjects.Add(poolObject);
            //pooledObjects.Push(poolObject);
            //ResetPoolObject(poolObject);
            return poolObject;
        }

        public void Push(IPoolable poolObject)
        {
            pooledObjects.Push(poolObject);
        }


        //public void Reset()
        //{
        //    foreach (var activeObject in activeObjects)
        //    {
        //        activeObject.ResetObject();
        //    }
        //}
    }

    public enum PoolObjectType
    {
        Difference,
        Particle
    }
}
