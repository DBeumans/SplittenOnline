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

    private void Start()
    {
        loader.OnLoadingCompleted += InstantiateCards;
    }

    private void OnEnable()
    {
        backButton.OnButtonClick += () =>
        {
            base.UIController.GoToScreen<MainScreen>();
        };
    }

    private void InstantiateCards()
    {
        this.Cards = loader.Deck;
        for (int i = 0; i < 4; i++)
        {
            CardUIButton cardObject = Instantiate(cardPrefab);
            cardObject.Card = Cards[i];
            cardObject.transform.SetParent(scrollView.transform);
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
