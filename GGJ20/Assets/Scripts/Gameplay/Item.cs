using UnityEngine;

public class Item : ClickDetection
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public ItemDialogueUI ItemDialogueUI;
    public ItemSO ItemSO;

    private bool m_owned;
    public bool Owned {
        get { return m_owned; }
    }

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    protected override void OnClick () {
        ItemDialogueUI.Open(this);
    }

    // ------------------------------------------------------------------------
    public void AddToInventory () {
        gameObject.SetActive(false);
        m_owned = true;
    }

    // ------------------------------------------------------------------------
    public void RemoveFromInventory () {
        gameObject.SetActive(true);
        m_owned = false;
    }
}