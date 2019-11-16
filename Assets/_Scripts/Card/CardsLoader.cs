using System;
using System.Collections.Generic;
using UnityEngine;
using Splitten.Extensions;
using Splitten.UI;

namespace Splitten.Cards
{
    public class CardsLoader : Singleton<CardsLoader>
    {

        [SerializeField]private CardUIButton cardPrefab;

        private string cardsDeckPath = "Sprites/Cards";

        public List<Card> Deck = new List<Card>();

        public Action OnLoadingCompleted;

        private void Start()
        {
            this.Load("Atlasnye");
        }

        public void Load(string cardsDeckName)
        {
            object[] cards = Resources.LoadAll(this.cardsDeckPath + "/" + cardsDeckName, typeof(Sprite));

            int cardsLength = cards.Length;
            int count = 0;
            CardType cardType = CardType.CLUBS;
                        
            for (int i = 0; i < cardsLength; i++)
            {
                count++;

                string currentCardFileName = cards[i].ToString();

                if (currentCardFileName.Contains("heart"))
                    cardType = CardType.HEARTS;
                if (currentCardFileName.Contains("diamond"))
                    cardType = CardType.DIAMONDS;
                if (currentCardFileName.Contains("club"))
                    cardType = CardType.CLUBS;
                if (currentCardFileName.Contains("spade"))
                    cardType = CardType.SPADES;
                
                Card card = new Card(count, cardType, (Sprite)cards[i]);
                if (count >= 13)
                    count = 0;

                this.Deck.Add(card);
            }

            this.OnLoadingCompleted?.Invoke();
        }
    }
}