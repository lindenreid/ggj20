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
        if(SpiritSO.VisitedChat) {
            ChatRunner.StartConversation(SpiritSO.SecondChat);
        } else {
            ChatRunner.StartConversation(SpiritSO.Chat);
        }
    }
}