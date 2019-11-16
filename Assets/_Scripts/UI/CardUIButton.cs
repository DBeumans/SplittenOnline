using UnityEngine;
using System.Collections;

using Splitten.UI;
using Splitten.Cards;
using UnityEngine.EventSystems;

public class CardUIButton : UIButton
{
    public Card Card;

    private void Test()
    {
        //this.imageComponent.sprite = Card.Sprite;
    }

    public CardUIButton(Card card)
    {
        this.Card = card;

        this.Test();
    }

}
