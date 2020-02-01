using UnityEngine;

[CreateAssetMenu(fileName = "Chat", menuName = "GreenTea/ScriptableObjects/Chat", order = 1)]
public class ChatSO : ScriptableObject 
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public int ID;
    public SpiritSO SpiritSO;
    public MessageSO[] Messages; // all of the messages

    // ------------------------------------------------------------------------
    // Properties
    // ------------------------------------------------------------------------
    public MessageSO FirstMessage {
        get { return Messages[0]; }
    }

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void Reset () {
        foreach(MessageSO message in Messages) {
            message.Reset();
        }
    }
}