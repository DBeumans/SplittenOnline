using UnityEngine;
using System.Collections;

using Splitten.UI;
using Splitten.Cards;
using UnityEngine.EventSystems;

public class CardUIButton : UIButton
{
    public Card Card;

    public void Test()
    {
        this.imageComponent.sprite = Card.Sprite;
    }

}
