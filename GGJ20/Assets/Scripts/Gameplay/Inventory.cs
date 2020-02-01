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
    private List<Item> m_items;

    public List<Item> Items {
        get{ return m_items; }
    }

    public List<ItemSO> ItemSOs {
        get{ 
            List<ItemSO> itemSOs = new List<ItemSO>();
            foreach(Item item in m_items) {
                itemSOs.Add(item.ItemSO);
            }
            return itemSOs;
         }
    }

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void ClearInventory () {
        m_items = new List<Item>();
        InventoryUI.Close();
    }

    // ------------------------------------------------------------------------
    public void AddItem (Item item) {
        m_items.Add(item);
    }

    // ------------------------------------------------------------------------
    public void RemoveItem (Item item) {
        if(m_items.Contains(item)) {
            m_items.Remove(item);
        }
    } 
}