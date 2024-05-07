using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteObject : MonoBehaviour, IPoolable
{
    [SerializeField] protected SpriteRenderer mainSpriteRenderer;

    public virtual PoolObjectType poolObjectType { get => PoolObjectType.Sprite; }

    public virtual void Initialize(Transform parent = null)
    {
        transform.SetParent(parent);
        transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        transform.localScale = Vector3.one;
        gameObject.SetActive(true);
    }

    public virtual void ResetObject(Transform parent = null)
    {
        SetSprite(null);
        transform.SetParent(parent);
        gameObject.SetActive(false);
    }

    public virtual void SetSprite(Sprite newSprite, int orderInLayer = 0, float spriteAlpha = 1f)
    {
        mainSpriteRenderer.sprite = newSprite;
        mainSpriteRenderer.sortingOrder = orderInLayer;
        mainSpriteRenderer.color = new Color(mainSpriteRenderer.color.r, mainSpriteRenderer.color.g, mainSpriteRenderer.color.b, spriteAlpha);
    }
}
