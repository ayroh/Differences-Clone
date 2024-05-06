using Pool;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

namespace Factory
{
    public class FactoryManager : MonoBehaviour
    {
        [Header("Parents")]
        [SerializeField] private Transform image1Parent;
        [SerializeField] private Transform image2Parent;


        public void FillDifferenceObjectPair(DifferenceObject difference1, DifferenceObject difference2, DifferenceData differenceData)
        {
            if(differenceData.difference1.sprite == null && differenceData.difference2.sprite == null)
            {
                Debug.LogError("FactoryManager: Fill, both difference sprites are null!");
                return;
            }

            difference1 = (DifferenceObject)PoolManager.instance.Get(PoolObjectType.Difference, image1Parent);
            if(differenceData.difference1.sprite == null)
            {
                difference1.SetSprite(null, differenceData.difference2.orderInLayer);
                difference1.transform.localPosition = differenceData.difference2.localPosition;
            }
            else
            {
                difference1.SetSprite(differenceData.difference1.sprite, differenceData.difference1.orderInLayer);
                difference1.transform.localPosition = differenceData.difference1.localPosition;
            }

            difference2 = (DifferenceObject)PoolManager.instance.Get(PoolObjectType.Difference, image2Parent);
            if (differenceData.difference2.sprite == null)
            {
                difference2.SetSprite(null, differenceData.difference1.orderInLayer);
                difference2.transform.localPosition = differenceData.difference1.localPosition;
            }
            else
            {
                difference2.SetSprite(differenceData.difference2.sprite, differenceData.difference2.orderInLayer);
                difference2.transform.localPosition = differenceData.difference2.localPosition;
            }

            difference1.SetPair(difference2);
            difference2.SetPair(difference1);
        }

        public void FillSpriteObjectPair(SpriteObject spriteObject1, SpriteObject spriteObject2, SpriteData spriteData)
        {
            spriteObject1 = (SpriteObject)PoolManager.instance.Get(PoolObjectType.Sprite, image1Parent);
            spriteObject1.SetSprite(spriteData.sprite, spriteData.orderInLayer);
            spriteObject1.transform.localPosition = spriteData.localPosition;

            spriteObject2 = (SpriteObject)PoolManager.instance.Get(PoolObjectType.Sprite, image2Parent);
            spriteObject2.SetSprite(spriteData.sprite, spriteData.orderInLayer);
            spriteObject2.transform.localPosition = spriteData.localPosition;
        }
    }
}
