using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Gravestone : ClickDetection
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public GameController GameController;

    public ChatSO SuccessChat;
    public ChatSO NegativeChat;
    public ChatSO FailureChat;

    public Inventory Inventory;
    public ChatRunner ChatRunner;
    public List<ItemSO> CorrectOffering;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    protected override void OnClick () {
        bool success = Inventory.ItemSOs.All(CorrectOffering.Contains)
                        && Inventory.Items.Count == CorrectOffering.Count;
        
        Inventory.ClearInventory();
        
        if(!success) {
            ChatRunner.StartConversation(FailureChat);
        } else if(GameController.GetWasDialoguePositive()) {
            ChatRunner.StartConversation(SuccessChat);
        } else {
            ChatRunner.StartConversation(NegativeChat);
        }
    }
}