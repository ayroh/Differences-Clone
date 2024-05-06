using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonObject : UIImageObject, IPoolable
{
    [SerializeField] private Button button;

    public override PoolObjectType poolObjectType { get => PoolObjectType.Button; }


    public void SetButtonActive(bool choice) => button.enabled = choice;


}
