using Cysharp.Threading.Tasks;
using Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Constants;
using Utilities.Signals;

public class UIManager : MonoBehaviour
{
    public void RestartGameButton() => Signals.OnRestartGame?.Invoke();
}
