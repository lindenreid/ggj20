using UnityEngine;

public class MapIcon : ClickDetection
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public LocationSO Location;

    
    public MaskFade m_MaskFade;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    protected override void OnClick () {
        Navigation.OpenLocation(Location, transform);
        if (m_MaskFade)
        {
            //m_MaskFade.ScaleMask();
        }
    }
    
}