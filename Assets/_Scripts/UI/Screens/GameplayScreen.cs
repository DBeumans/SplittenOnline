using UnityEngine;
using System.Collections.Generic;
using Splitten.UI;
using Splitten.Game;

public class GameplayScreen : UIScreen
{
    [SerializeField] private UIButton backButton;

    private GameManager gameManager;

    public CardUIButton cardPrefab;

    private void OnEnable()
    {
        backButton.OnButtonClick += () =>
        {
            base.UIController.GoToScreen<MainScreen>();
        };

        this.gameManager = GameManager.Instance;
    }

    public override void EnableScreen()
    {
        base.EnableScreen();

        this.gameManager.StartMatch();
    }

    public override void DisableScreen()
    {
        base.DisableScreen();
    }
}
