using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIImageObject : MonoBehaviour
{
    [SerializeField] private Image mainImage;

    //public virtual PoolObjectType poolObjectType { get => PoolObjectType.Image;}

    protected virtual void Awake() { }

    public void Initialize(Transform parent = null)
    {
        transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        transform.localScale = Vector3.one;
        transform.SetParent(parent);
        gameObject.SetActive(true);
    }

    public void ResetObject(Transform parent = null)
    {
        SetImage(null);
        gameObject.SetActive(false);
    }

    public void SetImage(Sprite newImage)
    {
        mainImage.sprite = newImage;
    }

}
