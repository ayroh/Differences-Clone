using Cysharp.Threading.Tasks;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Constants;

public class Life : UIImageObject, IPoolable
{
    [Header("References")]
    [SerializeField] private Image backgroundImage;
    [SerializeField] private new Animation animation;

    public PoolObjectType poolObjectType { get => PoolObjectType.Life; }

    public void KillInsideImageAnimation() => animation.Play("KillLife");

    private void ColorizeAnimation() => animation.Play("Colorize");

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
        gameObject.SetActive(false);
    }
}
