using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;

public class DifferenceObject : MonoBehaviour, IClickable, IPoolable
{

    [SerializeField] private SpriteRenderer mainSpriteRenderer;

    private DifferenceObject pairDifferenceObject;

    public PoolObjectType poolObjectType { get; set; } = PoolObjectType.Difference;


    public void Click()
    {
        throw new System.NotImplementedException();
    }

    public void Initialize(Transform parent = null)
    {
        transform.SetParent(parent);
        transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        transform.localScale = Vector3.one;
        gameObject.SetActive(true);
    }

    public void ResetObject(Transform parent = null)
    {
        SetSprite(null);
        transform.SetParent(parent);
        gameObject.SetActive(false);
    }

    public void SetSprite(Sprite newSprite)
    {
        mainSpriteRenderer.sprite = newSprite;
    }
}
