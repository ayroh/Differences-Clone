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
        Found();
        pairDifferenceObject.Found();
    }

    public void Found()
    {
        boxCollider.enabled = false;
    }

    public void SetPair(DifferenceObject pair) => pairDifferenceObject = pair;

    public override void SetSprite(Sprite newSprite, int orderInLayer = 0, float spriteAlpha = 1f)
    {
        base.SetSprite(newSprite, orderInLayer, spriteAlpha);

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
