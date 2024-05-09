using UnityEngine;
using Utilities.Signals;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public void RestartGameButton() => Signals.OnRestartGame?.Invoke();

        public void RefillLifesButton() => Signals.OnRefillLifes?.Invoke();
    }
}
