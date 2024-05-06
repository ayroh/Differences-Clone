using Pool;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

namespace Factory
{
    public class FactoryManager : MonoBehaviour
    {
        public DifferenceObject GetDifferenceObject(Sprite sprite)
        {
            DifferenceObject differenceObject = (DifferenceObject)PoolManager.instance.Get(PoolObjectType.Difference);
            differenceObject.SetSprite(sprite);
            return differenceObject;
        }
    }
}
