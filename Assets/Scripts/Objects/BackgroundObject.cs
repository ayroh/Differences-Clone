using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Signals;
using Pool;

public class BackgroundObject : SpriteObject, IPoolable, IClickable
{
    [SerializeField] private BoxCollider2D boxCollider;

    public override PoolObjectType poolObjectType { get => PoolObjectType.Background; }

    public void Click() => Signals.OnFailClick?.Invoke();

    public override void SetSprite(Sprite newSprite, int orderInLayer = 0, float spriteAlpha = 1f)
    {
        base.SetSprite(newSprite, orderInLayer);

        boxCollider.enabled = true;
        boxCollider.size = mainSpriteRenderer.size;
    }
}
