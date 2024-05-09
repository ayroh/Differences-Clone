using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Objects
{
    public abstract class UIButtonObject : UIImageObject
    {
        [SerializeField] private Button button;

        protected override void Awake() { }

        public void SetButtonActive(bool choice) => button.enabled = choice;


    }
}