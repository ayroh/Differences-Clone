using Cysharp.Threading.Tasks;
using Factory;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Constants;

public class CorrectCheck : SpriteObject, IClickable, IPoolable
{
    [Header("References")]
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Values")]
    [SerializeField] private AnimationCurve shakeCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    public override PoolObjectType poolObjectType { get => PoolObjectType.CorrectCheck; }

    private CorrectCheck pairCorrectCheck;

    public async void GrowFromZero()
    {
        boxCollider.enabled = false;

        float timer = .001f;
        float scaleValue = .01f;
        while (timer < Constants.CorrectCheckImageAnimationTime)
        {
            scaleValue = timer / Constants.CorrectCheckImageAnimationTime;
            transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
            timer += Time.deltaTime;
            await UniTask.NextFrame();
        }

        transform.localScale = Vector3.one;
        boxCollider.enabled = true;
    }

    public void Click()
    {
        Shake();
        pairCorrectCheck.Shake();
    }

    private async void Shake()
    {
        boxCollider.enabled = false;

        Vector2 direction = new Vector2(Extentions.RandomWithNegativeChance(.1f, .2f), Extentions.RandomWithNegativeChance(.1f, .2f));
        Vector2 startPos = transform.position;
        Vector2 endPos = (Vector2)transform.position + direction;

        float timer = 0f;
        while(timer < Constants.CorrectCheckClickShakeAnimationTime)
        {
            transform.position = Vector2.Lerp(startPos, endPos, shakeCurve.Evaluate(timer / Constants.CorrectCheckClickShakeAnimationTime));
            timer += Time.deltaTime;
            await UniTask.NextFrame();
        }

        transform.position = startPos;
        boxCollider.enabled = true;
    }

    public override void ResetObject(Transform parent = null)
    {
        transform.SetParent(parent);
        gameObject.SetActive(false);
    }

    public void SetPair(CorrectCheck pair) => pairCorrectCheck = pair;
}
