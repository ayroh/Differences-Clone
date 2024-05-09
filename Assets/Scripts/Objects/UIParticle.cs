using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;
using Cysharp.Threading.Tasks;

namespace Objects
{
    public abstract class UIParticle : MonoBehaviour, IPoolable
    {
        [SerializeField] protected ParticleSystem particle;


        public virtual PoolObjectType poolObjectType { get => PoolObjectType.NULL; }


        public virtual void Initialize(Transform parent = null)
        {
            transform.SetParent(parent, false);
            //transform.localScale = Vector3.one;
            //transform.position = Vector3.zero;
            gameObject.SetActive(true);
            particle.Play();
        }



        public virtual void ResetObject(Transform parent = null)
        {
            particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            gameObject.SetActive(false);
        }
    }
}