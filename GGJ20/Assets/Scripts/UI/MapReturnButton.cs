using UnityEngine;

public class MapReturnButton : ClickDetection
{
    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    protected override void OnClick () {
        base.Navigation.OpenMap();
    }
}