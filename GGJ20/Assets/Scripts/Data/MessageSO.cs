using UnityEngine;

public enum Spirit {
    Player = 0,
    Rabbit = 1
}

[CreateAssetMenu(fileName = "Message", menuName = "GreenTea/ScriptableObjects/Message", order = 1)]
public class MessageSO : ScriptableObject 
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public int Node;
    public Spirit Sender; // who sent this message
    public string[] Messages; // the text for the messages sent

    // all of the following map by index
    public string[] Options; // the text options
    public MessageSO[] Branch; // the next message

    public MessageSO Selection;

    // ------------------------------------------------------------------------
    // Properties
    // ------------------------------------------------------------------------
    public bool IsLeafMessage {get{return Branch == null || Branch.Length == 0;}}
    public bool HasOptions {get{return Options != null && Options.Length > 0;}}
    public bool Player {get{return Sender == Spirit.Player;}}

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void Reset () {
        Selection = null;
    }

    // ------------------------------------------------------------------------
    public void SelectOption (MessageSO option) {
        Selection = option;
    }
}