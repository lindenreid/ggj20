using UnityEngine;

public class Item : ClickDetection
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public ItemDialogueUI ItemDialogueUI;
    public ItemSO ItemSO;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    protected override void OnClick () {
        ItemDialogueUI.Open(ItemSO);
    }
}