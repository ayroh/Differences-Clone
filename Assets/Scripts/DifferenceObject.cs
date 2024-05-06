using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;
using Utilities.Constants;

public class DifferenceObject : MonoBehaviour, IClickable, IPoolable
{

    [SerializeField] private SpriteRenderer mainSpriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;

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

    public void SetPair(DifferenceObject pair) => pairDifferenceObject = pair;

    public void SetSprite(Sprite newSprite, int orderInLayer = 0)
    {
        mainSpriteRenderer.sprite = newSprite;
        mainSpriteRenderer.sortingOrder = orderInLayer;

        if(mainSpriteRenderer.sprite != null)
        {
            boxCollider.enabled = true;
            boxCollider.size = mainSpriteRenderer.size * Constants.SpriteColliderSizeConstant;
        }
        else
        {
            boxCollider.enabled = false;
        }
    }
}
