using UnityEngine;

public class MapIcon : ClickDetection
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public Navigation Navigation;
    public LocationSO Location;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    protected override void OnClick () {
        Navigation.OpenLocation(Location);
    }
}