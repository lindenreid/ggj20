using UnityEngine;

public class SpiritObj : ClickDetection
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public ChatRunner ChatRunner;
    public SpiritSO SpiritSO;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    protected override void OnClick () {
        ChatRunner.StartConversation(SpiritSO.Chat);
    }
}