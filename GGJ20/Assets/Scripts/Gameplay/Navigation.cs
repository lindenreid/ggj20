using UnityEngine;

public class Navigation : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public GameObject MapParent;
    public GameObject LocationParent;
    public GameObject MapReturnButton;

    public SpriteRenderer LocationBackground;

    private LocationSO ActiveLocation;

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

        ActiveLocation = locationSO;
    }
}