using UnityEngine;
using UnityEngine.UI;

public class MessageOptionUI : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public Button Button;
    public Text Text;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void Setup (
        MessageSO message,
        int index,
        ChatRunner chatRunner
    ) {
        Text.text = message.Options[index];

        Button.onClick.AddListener(
            delegate {chatRunner.SelectOption(message, index);}
        );
    }
}