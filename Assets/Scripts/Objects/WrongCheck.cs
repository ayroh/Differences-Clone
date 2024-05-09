using Cysharp.Threading.Tasks;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Constants;

namespace Objects
{
    public class WrongCheck : SpriteObject, IPoolable
    {
        public override PoolObjectType poolObjectType { get => PoolObjectType.WrongCheck; }


        public async void GrowAndRotate()
        {
            ScaleTo();
            await RotateTo();

            PoolManager.instance.Release(this);
        }

        private async void ScaleTo(float finalScale = 1)
        {
            float timer = 0f;
            float scaleValue = .01f;
            while (timer < Constants.WrongCheckAnimationTime)
            { 
                scaleValue = finalScale * Curves.instance.wrongCheckScaleCurve.Evaluate(timer / Constants.WrongCheckAnimationTime);
                transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
                timer += Time.deltaTime;
                await UniTask.NextFrame();
            }
            transform.localScale = new Vector3(finalScale, finalScale, finalScale);
        }

        private async UniTask RotateTo(float finalRotateZ = -45)
        {
            float timer = 0f;
            while (timer < Constants.WrongCheckAnimationTime)
            {
                transform.eulerAngles = new Vector3(0f, 0f, finalRotateZ * Curves.instance.wrongCheckRotationCurve.Evaluate(timer / Constants.WrongCheckAnimationTime));
                timer += Time.deltaTime;
                await UniTask.NextFrame();
            }
            transform.eulerAngles = new Vector3(0f, 0f, finalRotateZ);
        }


        public override void ResetObject(Transform parent = null)
        {
            gameObject.SetActive(false);
        }

    }
}