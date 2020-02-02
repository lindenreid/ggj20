using UnityEngine;
using UnityEngine.UI;

public class MainMenu : UIScreen
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public GameController GameController;
    public Navigation Navigation;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    protected override void OnEnable () {}
    protected override void OnDisable () {}

    // ------------------------------------------------------------------------
    public void StartGame () {
        gameObject.SetActive(false);
        Navigation.OpenMap();
        GameController.StartGame();
        FireClosed();
    }

    // ------------------------------------------------------------------------
    public void Open () {
        gameObject.SetActive(true);
        FireOpened();
    }
}