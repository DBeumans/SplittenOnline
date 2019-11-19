using UnityEngine;
using System.Collections.Generic;
using Splitten.UI;
using Splitten.Cards;

public class GameplayScreen : UIScreen
{
    [SerializeField] private UIButton backButton;

    [SerializeField] private CardsLoader loader;
    public List<Card> Cards = new List<Card>();

    public CardUIButton cardPrefab;

    [SerializeField] private GameObject scrollView;

    private void OnEnable()
    {
        backButton.OnButtonClick += () =>
        {
            base.UIController.GoToScreen<MainScreen>();
        };

        loader.OnLoadingCompleted += InstantiateCards;
    }

    private void InstantiateCards()
    {
        this.Cards = loader.Deck;
        for (int i = 0; i < this.Cards.Count; i++)
        {
            CardUIButton cardObject = Instantiate(cardPrefab);
            cardObject.transform.SetParent(scrollView.transform);
            cardObject.Card = Cards[i];
            cardObject.Test();
            
        }
    }

    public override void EnableScreen()
    {
        base.EnableScreen();
    }
    public override void DisableScreen()
    {
        base.DisableScreen();
    }
}
