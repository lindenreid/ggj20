using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class ChatUI : UIScreen
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public ChatRunner ChatRunner;
    public GameObject SpiritChatParent;
    public GameObject PlayerChatParent;
    public Transform MessageOptionsParent;
    public GameObject MessageOptionPrefab;

    public Image SpiritIcon;
    public Text SpiritName;
    public Text SpiritText;

    public float SpritIconSize = 2.0f;

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
    protected override void OnEnable () {}
    protected override void OnDisable () {}

    // ------------------------------------------------------------------------
    private void DrawChatBubble (MessageSO message, int index) {
        FireOpened();

        SpiritChatParent.SetActive(true);
        PlayerChatParent.SetActive(false);
        SpiritIcon.gameObject.SetActive(true);

        SpiritSO spirit = ChatRunner.ActiveChat.SpiritSO;
        SpiritIcon.sprite = spirit.Icon;
        SpiritIcon.SetNativeSize();
        SpiritIcon.rectTransform.sizeDelta *= SpritIconSize;

        SpiritName.text = spirit.Name;
        SpiritText.text = message.Messages[index];
    }

    // ------------------------------------------------------------------------
    private void DrawChatOptionBubble (MessageSO message, int option) {
        FireOpened();

        SpiritChatParent.SetActive(false);
        PlayerChatParent.SetActive(true);
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
        Exit();
    }

    // ------------------------------------------------------------------------
    public void Exit () {
        FireClosed();

        SpiritChatParent.SetActive(false);
        PlayerChatParent.SetActive(false);
        SpiritIcon.gameObject.SetActive(false);
    }
}