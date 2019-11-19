using System;
using UnityEngine;
using Splitten.UI;

public class MainScreen : UIScreen
{
    [SerializeField] private UIButton backButton;
    [SerializeField] private UIButton deckButton;

    private void OnEnable()
    {
        backButton.OnButtonClick += () =>
        {
            base.UIController.GoToScreen<LandingScreen>();
        };

        deckButton.OnButtonClick += () =>
        {
            base.UIController.GoToScreen<GameplayScreen>();
        };
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
