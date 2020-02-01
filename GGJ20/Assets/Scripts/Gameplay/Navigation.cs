using System.Collections.Generic;

using UnityEngine;

public class Navigation : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public List<UIScreen> UIScreens;
    public GameObject MapParent;
    public GameObject LocationParent;
    public GameObject MapReturnButton;

    public SpriteRenderer LocationBackground;

    private LocationSO ActiveLocation;

    // this bad, idc
    public GameObject GraveLocation;
    public GameObject ForestLocation;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void OpenMap () {
        MapParent.SetActive(true);
        LocationParent.SetActive(false);
        MapReturnButton.SetActive(false);
    }

    // ------------------------------------------------------------------------
    public void OpenLocation (LocationSO locationSO) {
        MapParent.SetActive(false);
        LocationParent.SetActive(true);
        MapReturnButton.SetActive(true);

        LocationBackground.sprite = locationSO.Background;

        // i don't literally care that this is bad
        // scenes who? idk her
        switch(locationSO.LocationType) {
            case LocationType.Grave :
                GraveLocation.SetActive(true);
                ForestLocation.SetActive(false);
                break;
            case LocationType.Forest : 
                GraveLocation.SetActive(false);
                ForestLocation.SetActive(true);
                break;
        }

        ActiveLocation = locationSO;
    }
}