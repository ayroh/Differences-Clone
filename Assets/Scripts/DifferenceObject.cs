using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;
using Utilities.Constants;

public class DifferenceObject : SpriteObject, IClickable, IPoolable
{

    [SerializeField] private BoxCollider2D boxCollider;

    private DifferenceObject pairDifferenceObject;

    //public PoolObjectType poolObjectType { get; set; } = PoolObjectType.Difference;

    private void Awake()
    {
        poolObjectType = PoolObjectType.Difference;
    }

    public void Click()
    {
        throw new System.NotImplementedException();
    }

    public void SetPair(DifferenceObject pair) => pairDifferenceObject = pair;

    public override void SetSprite(Sprite newSprite, int orderInLayer = 0)
    {
        base.SetSprite(newSprite, orderInLayer);

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
