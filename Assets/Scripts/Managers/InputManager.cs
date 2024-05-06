using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utilities.Enums;
using Utilities.Signals;

public class InputManager : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Camera cam;

    [Header("Values")]
    [SerializeField] private LayerMask clickableLayers;

    private int inputCount = 0;

    private RaycastHit2D[] hit = new RaycastHit2D[1];


    public void SetInputState(bool input)
    {
        if (input)
            inputCount++;
        else
            inputCount--;
    }

    void Update()
    {
        if (inputCount != 0 || GameManager.gameState != GameState.Play)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics2D.RaycastNonAlloc(ray.origin, ray.direction, hit, 100f, clickableLayers) != 0)
            {
                hit[0].transform.GetComponent<IClickable>().Click();
            }
            else
            {
                // Can azalt
            }
        }
    }

    private void OnEnable() => Signals.OnInputAdd += SetInputState;
    private void OnDisable() => Signals.OnInputAdd -= SetInputState;


}
