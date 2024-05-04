using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Utilities.Signal
{
    public static class Signals
    {

        public static Action<bool> OnInputAdd = delegate { };

        public static Action<bool/*enum*/> OnLevelStatusChanged = delegate { };


    }
}
