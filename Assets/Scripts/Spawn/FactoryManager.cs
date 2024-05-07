using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public class FactoryManager : Singleton<FactoryManager>
    {
        [Header("Parents")]
        [SerializeField] private Transform image1Parent;
        [SerializeField] private Transform image2Parent;
        [SerializeField] private RectTransform canvas;


        public void FillDifferenceObjectPair(DifferenceObject difference1, DifferenceObject difference2, DifferenceData differenceData)
        {
            if(differenceData.difference1.sprite == null && differenceData.difference2.sprite == null)
            {
                Debug.LogError("FactoryManager: FillDifferenceObjectPair, both difference sprites are null!");
                return;
            }

            difference1 = (DifferenceObject)PoolManager.instance.Get(PoolObjectType.Difference, image1Parent);
            if(differenceData.difference1.sprite != null)
            {
                difference1.SetSprite(differenceData.difference1.sprite, differenceData.difference1.orderInLayer);
                difference1.transform.localPosition = differenceData.difference1.localPosition;
            }
            else
            {
                difference1.SetSprite(differenceData.difference2.sprite, differenceData.difference2.orderInLayer, 0f);
                difference1.transform.localPosition = differenceData.difference2.localPosition;
            }

            difference2 = (DifferenceObject)PoolManager.instance.Get(PoolObjectType.Difference, image2Parent);
            if (differenceData.difference2.sprite != null)
            {
                difference2.SetSprite(differenceData.difference2.sprite, differenceData.difference2.orderInLayer);
                difference2.transform.localPosition = differenceData.difference2.localPosition;
            }
            else
            {
                difference2.SetSprite(differenceData.difference1.sprite, differenceData.difference1.orderInLayer, 0f);
                difference2.transform.localPosition = differenceData.difference1.localPosition;
            }

            difference1.SetPair(difference2);
            difference2.SetPair(difference1);
        }

        public void FillSpriteObjectPair(SpriteObject spriteObject1, SpriteObject spriteObject2, SpriteData spriteData)
        {
            if (spriteData.sprite == null)
            {
                Debug.LogError("FactoryManager: FillSpriteObjectPair, sprite is null!");
                return;
            }
            spriteObject1 = (SpriteObject)PoolManager.instance.Get(PoolObjectType.Sprite, image1Parent);
            spriteObject1.SetSprite(spriteData.sprite, spriteData.orderInLayer);
            spriteObject1.transform.localPosition = spriteData.localPosition;

            spriteObject2 = (SpriteObject)PoolManager.instance.Get(PoolObjectType.Sprite, image2Parent);
            spriteObject2.SetSprite(spriteData.sprite, spriteData.orderInLayer);
            spriteObject2.transform.localPosition = spriteData.localPosition;
        }

        public void FillCorrectCheckPair(CorrectCheck correctCheck1, CorrectCheck correctCheck2, Vector2 pos1, Vector2 pos2)
        {
            correctCheck1 = (CorrectCheck)PoolManager.instance.Get(PoolObjectType.CorrectCheck, image1Parent);
            correctCheck1.transform.position = pos1;
            correctCheck1.GrowFromZero();
            
            correctCheck2 = (CorrectCheck)PoolManager.instance.Get(PoolObjectType.CorrectCheck, image2Parent);
            correctCheck2.transform.position = pos2;
            correctCheck2.GrowFromZero();

            correctCheck1.SetPair(correctCheck2);
            correctCheck2.SetPair(correctCheck1);
        }

        //public UIImageObject GetUIImageObject(Sprite image, Vector2 screenPos)
        //{
        //    UIImageObject uiImageObject = (UIImageObject)PoolManager.instance.Get(PoolObjectType.Image, canvas);
        //    uiImageObject.SetImage(image);
        //    uiImageObject.transform.position = screenPos;
        //    return uiImageObject;
        //}

    }
}
