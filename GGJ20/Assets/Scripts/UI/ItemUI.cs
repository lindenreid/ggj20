using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public Image Image;
    public Button Button;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void SetItem (Item item, ItemDialogueUI itemUI) {
        Image.sprite = item.ItemSO.BagIcon;

        Button.onClick.AddListener(
            delegate {itemUI.Open(item);}
        );
    }
}