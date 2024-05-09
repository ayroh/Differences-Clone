using Cysharp.Threading.Tasks;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Constants;

namespace Objects
{
    public class CorrectCheck : SpriteObject, IClickable, IPoolable
    {
        [Header("References")]
        [SerializeField] private BoxCollider2D boxCollider;

        public override PoolObjectType poolObjectType { get => PoolObjectType.CorrectCheck; }

        private bool isShaking = false;
        private CorrectCheck pairCorrectCheck;

        public async void GrowFromZero(float finalScale = 1)
        {
            if (finalScale <= 0f)
            {
                Debug.LogError("CorrectCheck: GrowFromZero, final scale is below zero!");
                return;
            }

            boxCollider.enabled = false;

            float timer = .001f;
            float scaleValue = .01f;
            while (timer < Constants.CorrectCheckImageAnimationTime)
            {
                scaleValue = (timer / Constants.CorrectCheckImageAnimationTime) * finalScale;
                transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
                timer += Time.deltaTime;
                await UniTask.NextFrame();
            }

            transform.localScale = new Vector3(finalScale, finalScale, finalScale);
            boxCollider.enabled = true;
        }

        public void Click()
        {
            if (pairCorrectCheck == null)
            {
                Debug.LogError("CorrectCheck: Click, pair CorrectCheck is null!");
                return;
            }

            Shake();
            pairCorrectCheck.Shake();
        }

        private async void Shake()
        {
            if (isShaking)
                return;

            isShaking = true;

            Vector2 direction = new Vector2(Extentions.RandomWithNegativeChance(.1f, .2f), Extentions.RandomWithNegativeChance(.1f, .2f));
            Vector2 startPos = transform.position;
            Vector2 endPos = (Vector2)transform.position + direction;

            float timer = 0f;
            while (timer < Constants.CorrectCheckClickShakeAnimationTime)
            {
                transform.position = Vector2.Lerp(startPos, endPos, Curves.instance.correctCheckBounceCurve.Evaluate(timer / Constants.CorrectCheckClickShakeAnimationTime));
                timer += Time.deltaTime;
                await UniTask.NextFrame();
            }
            transform.position = startPos;

            isShaking = false;
        }

        public override void ResetObject(Transform parent = null)
        {
            transform.SetParent(parent);
            gameObject.SetActive(false);
        }

        public void SetPair(CorrectCheck pair) => pairCorrectCheck = pair;
    }
}