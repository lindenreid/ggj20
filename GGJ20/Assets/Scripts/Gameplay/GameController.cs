using UnityEngine;

public class GameController : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public Inventory Inventory;
    public MainMenu MainMenu;

    // this should really be in its own data class but idgaf
    private int m_totalMessages;
    private int m_messageScore;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void StartGame () {
        Inventory.ClearInventory();
        m_messageScore = 0;
        m_totalMessages = 0;
    }

    // ------------------------------------------------------------------------
    public void RecordDialogueChoice (MessageType type) {
        switch(type) {
            case MessageType.Neutral : break;
            case MessageType.Positive :
                m_messageScore ++;
                m_totalMessages ++;
                break;
            case MessageType.Negative : 
                m_totalMessages ++;
                break;
        }
    }

    // ------------------------------------------------------------------------
    public void LastConvoFinished () {
        MainMenu.Open();
    }

    // ------------------------------------------------------------------------
    public bool GetWasDialoguePositive () {
        Debug.Log("total messages: " + m_totalMessages);
        Debug.Log("messages answered positively: " + m_messageScore);

        if(m_totalMessages == 0) return false;

        float score = (float)m_messageScore / (float)m_totalMessages;
        Debug.Log("score: " + score);
        return score >= 0.5f;
    }
}