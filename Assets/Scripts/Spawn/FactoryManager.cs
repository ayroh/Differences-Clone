using LifeManage;
using Objects;
using Pool;
using ScoreManage;
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
        [SerializeField] private RectTransform particleCanvas;

        [Header("References")]
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private Camera mainCam;



        public void CreateDifferenceObjectPair(DifferenceData differenceData)
        {
            if(differenceData.difference1.sprite == null && differenceData.difference2.sprite == null)
            {
                Debug.LogError("FactoryManager: FillDifferenceObjectPair, both difference sprites are null!");
                return;
            }

            DifferenceObject difference1 = (DifferenceObject)PoolManager.instance.Get(PoolObjectType.Difference, image1Parent);
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

            DifferenceObject difference2 = (DifferenceObject)PoolManager.instance.Get(PoolObjectType.Difference, image2Parent);
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

        public void CreateSpriteObjectPair(SpriteData spriteData)
        {
            if (spriteData.sprite == null)
            {
                Debug.LogError("FactoryManager: FillSpriteObjectPair, sprite is null!");
                return;
            }
            SpriteObject spriteObject1 = (SpriteObject)PoolManager.instance.Get(PoolObjectType.Sprite, image1Parent);
            spriteObject1.SetSprite(spriteData.sprite, spriteData.orderInLayer);
            spriteObject1.transform.localPosition = spriteData.localPosition;

            SpriteObject spriteObject2 = (SpriteObject)PoolManager.instance.Get(PoolObjectType.Sprite, image2Parent);
            spriteObject2.SetSprite(spriteData.sprite, spriteData.orderInLayer);
            spriteObject2.transform.localPosition = spriteData.localPosition;
        }

        public void CreateCorrectCheckPair(Vector2 pos1, Vector2 pos2)
        {
            float noisedScale = Extentions.Noise(1, .15f);

            CorrectCheck correctCheck1 = (CorrectCheck)PoolManager.instance.Get(PoolObjectType.CorrectCheck, image1Parent);
            correctCheck1.transform.position = pos1;
            correctCheck1.GrowFromZero(noisedScale);

            CorrectCheck correctCheck2 = (CorrectCheck)PoolManager.instance.Get(PoolObjectType.CorrectCheck, image2Parent);
            correctCheck2.transform.position = pos2;
            correctCheck2.GrowFromZero(noisedScale);

            correctCheck1.SetPair(correctCheck2);
            correctCheck2.SetPair(correctCheck1);
        }

        public Life GetLife()
        {
            Life newLife = (Life)PoolManager.instance.Get(PoolObjectType.Life);
            return newLife;
        }

        public Score GetScore()
        {
            Score newScore = (Score)PoolManager.instance.Get(PoolObjectType.Score);
            return newScore;
        }

        public void CreateBackgrounds(SpriteData spriteData)
        {
            BackgroundObject backgroundObject1 = (BackgroundObject)PoolManager.instance.Get(PoolObjectType.Background, image1Parent);
            backgroundObject1.transform.localPosition = Vector3.zero;
            backgroundObject1.SetSprite(spriteData.sprite, spriteData.orderInLayer);

            BackgroundObject backgroundObject2 = (BackgroundObject)PoolManager.instance.Get(PoolObjectType.Background, image2Parent);
            backgroundObject2.transform.localPosition = Vector3.zero;
            backgroundObject2.SetSprite(spriteData.sprite, spriteData.orderInLayer);
        }

        public void CreateFoundParticle(Vector3 differenceObjectWorldPosition)
        {
            FoundParticle foundParticle = (FoundParticle)PoolManager.instance.Get(PoolObjectType.FoundParticle, particleCanvas);
            foundParticle.DragToPointAndRelease(mainCam.WorldToScreenPoint(differenceObjectWorldPosition), scoreManager.GetCurrentScoreCanvasPosition());
        }

        public void CreateWrongCheck(Vector2 screenPos)
        {
            WrongCheck wrongCheck = (WrongCheck)PoolManager.instance.Get(PoolObjectType.WrongCheck);
            wrongCheck.transform.position = mainCam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, -mainCam.transform.position.z));
            wrongCheck.GrowAndRotate();
        }

    }
}
