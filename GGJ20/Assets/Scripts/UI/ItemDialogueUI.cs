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

    private ItemSO m_itemSO;
    
    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void Open (ItemSO item) {
        gameObject.SetActive(true);

        Title.text = item.Name;
        Description.text = item.Description;
        ItemImage.sprite = item.Icon;

        m_itemSO = item;
    }

    // ------------------------------------------------------------------------
    public void Close () {
        gameObject.SetActive(false);
    }

    // ------------------------------------------------------------------------
    public void AddToInventory () {
        Inventory.AddItem(m_itemSO);

        Close();
        InventoryUI.Open();
    }
}