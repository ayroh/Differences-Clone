using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;
using Utilities.Constants;
using Factory;
using Utilities.Signals;

public class DifferenceObject : SpriteObject, IClickable, IPoolable
{

    [SerializeField] private BoxCollider2D boxCollider;

    private DifferenceObject pairDifferenceObject;

    public override PoolObjectType poolObjectType { get => PoolObjectType.Difference; }

    public void Click()
    {
        Found();
        pairDifferenceObject.Found();

        CorrectCheck correctCheck1 = null, correctCheck2 = null;
        FactoryManager.instance.FillCorrectCheckPair(correctCheck1, correctCheck2, transform.position, pairDifferenceObject.transform.position);
        Signals.OnFound?.Invoke();
    }

    public void Found()
    {
        boxCollider.enabled = false;
        //UIManager.instance.CreateCorrectCheckButton(transform.position);
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
