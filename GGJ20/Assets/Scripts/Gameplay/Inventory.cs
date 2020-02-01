using System.Collections.Generic;

using UnityEngine;

public class Inventory : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public InventoryUI InventoryUI;

    // ------------------------------------------------------------------------
    // Properties
    // ------------------------------------------------------------------------
    private List<ItemSO> m_items;
    public List<ItemSO> Items {
        get{ return m_items; }
    }

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void ClearInventory () {
        m_items = new List<ItemSO>();
    }

    // ------------------------------------------------------------------------
    public void AddItem (ItemSO item) {
        m_items.Add(item);
    }

    // ------------------------------------------------------------------------
    public void RemoveItem (ItemSO item) {
        if(m_items.Contains(item)) {
            m_items.Remove(item);
        }
    } 
}