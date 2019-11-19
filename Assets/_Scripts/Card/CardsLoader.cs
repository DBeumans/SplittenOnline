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
            this.LoadDeck("Atlasnye");
        }

        public void LoadDeck(string deckName)
        {
            this.Deck = this.Load(deckName);
            this.OnLoadingCompleted?.Invoke();
        }

        private List<Card> Load(string cardsDeckName)
        {
            object[] cards = Resources.LoadAll(this.cardsDeckPath + "/" + cardsDeckName, typeof(Sprite));
            List<Card> deck = new List<Card>();
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
                if (currentCardFileName.Contains("joker"))
                    cardType = CardType.JOKER;
                
                Card card = new Card(count, cardType, (Sprite)cards[i]);
                if (count >= 13)
                    count = 0;

                deck.Add(card);
            }
            
            return deck;
        }
    }
}