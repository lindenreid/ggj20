using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class ChatUI : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public ChatRunner ChatRunner;
    public GameObject SpiritChatParent;
    public GameObject PlayerChatParent;
    public Transform MessageOptionsParent;
    public GameObject MessageOptionPrefab;
    public GameObject ExitButton;

    public Image SpiritIcon;
    public Text SpiritName;
    public Text SpiritText;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    void Awake () {
        ChatRunner.VisitedMessage += DrawChatBubble;
        ChatRunner.VisitedOption += DrawChatOptionBubble;
        ChatRunner.SelectedOption += HandleSelectedOption;
        ChatRunner.ReachedLeafNode += HandleReachedLeafNode;
    }

    // ------------------------------------------------------------------------
    private void DrawChatBubble (MessageSO message, int index) {
        SpiritChatParent.SetActive(true);
        PlayerChatParent.SetActive(false);
        ExitButton.SetActive(false);
        SpiritIcon.gameObject.SetActive(true);

        SpiritSO spirit = ChatRunner.ActiveChat.SpiritSO;
        SpiritIcon.sprite = spirit.Icon;
        SpiritName.text = spirit.Name;
        SpiritText.text = message.Messages[index];
    }

    // ------------------------------------------------------------------------
    private void DrawChatOptionBubble (MessageSO message, int option) {
        SpiritChatParent.SetActive(false);
        PlayerChatParent.SetActive(true);
        ExitButton.SetActive(false);
        SpiritIcon.gameObject.SetActive(true);

        GameObject bubble =
            Instantiate(MessageOptionPrefab, MessageOptionsParent)
            as GameObject;

        MessageOptionUI ui = bubble.GetComponent<MessageOptionUI>();
        Assert.IsNotNull(ui, "MessageOptionUI null.");
        ui.Setup(message, option, ChatRunner);
    }

    // ------------------------------------------------------------------------
    private void HandleSelectedOption () {
        // clear options
        foreach(Transform t in MessageOptionsParent.transform) {
            Destroy(t.gameObject);
        }
    }

    // ------------------------------------------------------------------------
    private void HandleReachedLeafNode () {
        ExitButton.SetActive(true);
    }

    // ------------------------------------------------------------------------
    public void Exit () {
        SpiritChatParent.SetActive(false);
        PlayerChatParent.SetActive(false);
        ExitButton.SetActive(false);
        SpiritIcon.gameObject.SetActive(false);
    }
}