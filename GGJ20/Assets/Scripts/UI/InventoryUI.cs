using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public Inventory Inventory;
    
    public GameObject ItemPrefab;
    public Transform InventoryParent;

    public GameObject InventoryButton;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void Open () {
        gameObject.SetActive(true);
        InventoryButton.SetActive(false);

        foreach(ItemSO item in Inventory.Items) {
            GameObject itemObj = Instantiate(ItemPrefab, InventoryParent)
                as GameObject;
            ItemUI itemUI = itemObj.GetComponent<ItemUI>();
            if(itemUI != null) {
                itemUI.SetItem(item);
            }
        }
    }

    // ------------------------------------------------------------------------
    public void Close () {
        gameObject.SetActive(false);
        InventoryButton.SetActive(true);

        foreach(Transform t in InventoryParent.transform) {
            Destroy(t.gameObject);
        }
    }
}