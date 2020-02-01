using UnityEngine;

public class MapIcon : ClickDetection
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public LocationSO Location;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    protected override void OnClick () {
        Navigation.OpenLocation(Location); 
    }
}