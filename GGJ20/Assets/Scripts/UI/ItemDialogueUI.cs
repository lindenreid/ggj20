using UnityEngine;
using UnityEngine.UI;

public class ItemDialogueUI : UIScreen
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public Inventory Inventory;
    public InventoryUI InventoryUI;

    public Image ItemImage;
    public Text Title;
    public Text Description;

    public GameObject AddButton;
    public GameObject RemoveButton;

    public float ItemSizeDelta = 1.5f;

    private Item m_item;
    
    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void Open (Item item) {
        gameObject.SetActive(true);

        Title.text = item.ItemSO.Name;
        Description.text = item.ItemSO.Description;

        ItemImage.sprite = item.ItemSO.Icon;
        ItemImage.SetNativeSize();
        ItemImage.rectTransform.sizeDelta *= ItemSizeDelta;

        if(item.Owned) {
            AddButton.SetActive(false);
            RemoveButton.SetActive(true);
        } else {
            AddButton.SetActive(true);
            RemoveButton.SetActive(false);
        }

        m_item = item;
    }

    // ------------------------------------------------------------------------
    public void Close () {
        gameObject.SetActive(false);
    }

    // ------------------------------------------------------------------------
    public void AddToInventory () {
        m_item.AddToInventory();
        Inventory.AddItem(m_item);

        Close();
        InventoryUI.Open();
    }

    // ------------------------------------------------------------------------
    public void RemoveFromInventory () {
        m_item.RemoveFromInventory();
        Inventory.RemoveItem(m_item);

        Close();
        InventoryUI.Open();
    }
}