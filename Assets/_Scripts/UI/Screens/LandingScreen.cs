using UnityEngine;
using Splitten.UI;

public class LandingScreen : UIScreen
{
    [SerializeField] private UIButton proceedButton;

    private void OnEnable()
    {
        proceedButton.OnButtonClick += () =>
        {
            base.UIController.GoToScreen<MainScreen>();
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
