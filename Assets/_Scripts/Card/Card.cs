using UnityEngine;

namespace Splitten.Cards
{
    public class Card
    {
        public int value;

        public Sprite Sprite;
        public CardType Type;

        public bool faceUp;

        public Card()
        {

        }
        public Card(int value, CardType type, Sprite sprite)
        {
            this.value = value;
            this.Type = type;
            this.Sprite = sprite;

            //Debug.Log($"Card: {this.value} + {this.Type} Sprite: {this.Sprite}");
        }

    }

}