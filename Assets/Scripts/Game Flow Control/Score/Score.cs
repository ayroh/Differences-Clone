using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Constants;

public class Score : UIImageObject, IPoolable
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Animation scoreAnimation;

    public virtual PoolObjectType poolObjectType { get => PoolObjectType.Score; }

    public void FoundAnimation() => scoreAnimation.Play(Constants.ScoreFoundAnimationName);

    private void ColorizeAnimation() => scoreAnimation.Play(Constants.ScoreColorizeAnimationName);

    public override void Initialize(Transform parent = null)
    {
        transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        transform.localScale = Vector3.one;
        gameObject.SetActive(true);
        mainImage.gameObject.SetActive(true);
        ColorizeAnimation();
    }

    public override void ResetObject(Transform parent = null)
    {
        //transform.SetParent(parent);
        gameObject.SetActive(false);
    }

}
