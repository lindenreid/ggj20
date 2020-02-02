using UnityEngine;

public class GameController : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public Inventory Inventory;

    // this should really be in its own data class but idgaf
    private int m_totalMessages;
    private int m_messageScore;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    void Start () {
        Inventory.ClearInventory();
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
    public bool GetWasDialoguePositive () {
        Debug.Log("total messages: " + m_totalMessages);
        Debug.Log("messages answered positively: " + m_messageScore);

        if(m_totalMessages == 0) return false;

        float score = (float)m_messageScore / (float)m_totalMessages;
        Debug.Log("score: " + score);
        return score >= 0.5f;
    }
}