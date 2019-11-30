using UnityEngine;
using System;
using System.Collections;
using Splitten.Extensions;

namespace Splitten.Game
{
    public class GameManager : Singleton<GameManager>
    {
        private GameReferee gameReferee;

        public Action OnMatchStarted;

        private void Awake()
        {
            this.gameReferee = GameReferee.Instance;
        }

        public void StartMatch()
        {
            this.gameReferee.Setup();
            this.OnMatchStarted?.Invoke();
        }
    }
}

