using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Signals;

public class LifeManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform lifeParent;

    private int currentLife;
    private int maxLife = 3;


    private void DecreaseLife()
    {
        if (currentLife == 0)
            return;

        if(--currentLife == 0)
            Signals.OnLifeEnded?.Invoke();
    }


    private void OnEnable() => Signals.OnFailClick += DecreaseLife;
    private void OnDisable() => Signals.OnFailClick -= DecreaseLife;
}
