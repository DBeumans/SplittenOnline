using UnityEngine;
using System.Collections.Generic;
using Splitten.Cards;
using Splitten.Extensions;

namespace Splitten.Game
{
    public class GameReferee : Singleton<GameReferee>
    {
        private List<Card> gameRefereeDeck = new List<Card>();

        public void Setup()
        {
            this.gameRefereeDeck = CardsLoader.Instance.LoadDeck("Atlasnye");
            Debug.Log($"Cards: {this.gameRefereeDeck.Count}");
        }
    }
}

