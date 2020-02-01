using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public Image Image;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void SetItem (ItemSO itemSO) {
        Image.sprite = itemSO.Icon;
    }
}