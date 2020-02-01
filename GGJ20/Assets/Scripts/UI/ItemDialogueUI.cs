using UnityEngine;
using UnityEngine.UI;

public class ItemDialogueUI : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public Inventory Inventory;
    public InventoryUI InventoryUI;

    public Image ItemImage;
    public Text Title;
    public Text Description;

    private Item m_item;
    
    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void Open (Item item) {
        gameObject.SetActive(true);

        Title.text = item.ItemSO.Name;
        Description.text = item.ItemSO.Description;
        ItemImage.sprite = item.ItemSO.Icon;

        m_item = item;
    }

    // ------------------------------------------------------------------------
    public void Close () {
        gameObject.SetActive(false);
    }

    // ------------------------------------------------------------------------
    public void AddToInventory () {
        m_item.AddToInventory();
        Inventory.AddItem(m_item.ItemSO);

        Close();
        InventoryUI.Open();
    }
}