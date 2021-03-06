using UnityEngine;

[CreateAssetMenu(fileName = "Spirit", menuName = "GreenTea/ScriptableObjects/Spirit", order = 1)]
public class SpiritSO : ScriptableObject 
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public string Name;
    public Sprite Icon;
    public ChatSO Chat;
    public ChatSO SecondChat;
    public bool VisitedChat;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void Reset () {
        VisitedChat = false;
    }
}