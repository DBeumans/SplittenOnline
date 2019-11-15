using System;
using UnityEngine;
using Splitten.UI;

public class MainScreen : UIScreen
{
    [SerializeField] private UIButton backButton;

    private void OnEnable()
    {
        backButton.OnButtonClick += () =>
        {
            base.UIController.GoToScreen<LandingScreen>();
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
