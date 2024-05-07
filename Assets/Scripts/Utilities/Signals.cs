using System;
using System.Collections;
using System.Collections.Generic;
using Utilities.Enums;


namespace Utilities.Signals
{
    public static class Signals
    {

        public static Action<bool> OnInputAdd = delegate { };

        public static Action<GameState> OnGameStateChanged = delegate { };

        public static Action OnGameStart = delegate { };

        public static Action OnDifferenceFound = delegate { };

        public static Action OnFailClick = delegate { };

        public static Action OnLifeEnded = delegate { };

        public static Action OnScoreFinished = delegate { };

        public static Action OnFound = delegate { };
    }
}
