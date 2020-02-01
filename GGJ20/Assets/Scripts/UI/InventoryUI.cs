using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public Inventory Inventory;
    public ItemDialogueUI ItemDialogueUI;
    
    public GameObject ItemPrefab;
    public Transform InventoryParent;

    private bool m_open;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void ToggleOpen () {
        if(m_open) {
            Close();
        } else {
            Open();
        }
    }

    // ------------------------------------------------------------------------
    public void Open () {
        gameObject.SetActive(true);
        m_open = true;

        if(m_open) {
            Clear();
        }

        foreach(Item item in Inventory.Items) {
            GameObject itemObj = Instantiate(ItemPrefab, InventoryParent)
                as GameObject;
            ItemUI itemUI = itemObj.GetComponent<ItemUI>();
            if(itemUI != null) {
                itemUI.SetItem(item, ItemDialogueUI);
            }
        }
    }

    // ------------------------------------------------------------------------
    public void Close () {
        gameObject.SetActive(false);
        m_open = false;

        Clear();
    }

    // ------------------------------------------------------------------------
    private void Clear () {
        foreach(Transform t in InventoryParent.transform) {
            Destroy(t.gameObject);
        }
    }
}