using System.Collections;

using UnityEngine;

public class ChatRunner : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    // hook into these with your UI class in order to draw chat bubbles
    public delegate void MessageDelegate(MessageSO message, int index);
    public event MessageDelegate VisitedMessage;

    public delegate void OptionDelegate(MessageSO message, int option);
    public event OptionDelegate VisitedOption;

    public delegate void LeafNodeDelegate();
    public event LeafNodeDelegate ReachedLeafNode;

    public delegate void SelectedOptionDelegate();
    public event SelectedOptionDelegate SelectedOption;

    private MessageSO m_lastMessage;

    private IEnumerator m_RunMessageCoroutine;
    private IEnumerator m_RunBubblesCoroutine;

    // settings
    public float MaxTimeBetweenMessages = 2f;

    // ------------------------------------------------------------------------
    // Properties
    // ------------------------------------------------------------------------
    private ChatSO m_activeChat;
    public ChatSO ActiveChat {get{return m_activeChat;}}

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void StartConversation (ChatSO chat) {
        m_activeChat = chat;
        chat.Reset();
        Debug.Log("opening chat: " + chat.ID);
        
        m_RunMessageCoroutine = RunMessage(m_activeChat.FirstMessage);
        StartCoroutine(m_RunMessageCoroutine);
    }

    // ------------------------------------------------------------------------
    public void MoveConversation () {
        if(m_activeChat == null) {
            Debug.Log("Trying to move in conversation that hasn't been set.");
            return;
        }

        // find next message in convo (if this isn't a leaf)
        if(!m_lastMessage.IsLeafMessage) {
            MessageSO nextMessage = null;
            // find the next message's node
            if(m_lastMessage.Selection != null) {
                nextMessage = m_lastMessage.Selection;
            } else {
                nextMessage = m_lastMessage.Branch[0];
            }

            // run it
            if(nextMessage != null) {
                m_RunMessageCoroutine = RunMessage(nextMessage);
                StartCoroutine(m_RunMessageCoroutine);
            } else {
                Debug.LogError("Could not find next message from node " + m_lastMessage.Node);
            }
        } else {
            // if this is a leaf node, send leaf node event
            // don't run more messages
            FinishChat();
        }
    }

    // ------------------------------------------------------------------------
    private IEnumerator RunMessage(MessageSO message) {
        if(message == null) {
            Debug.LogError("Message null.");
            yield break;
        }

        //Debug.Log("running message: " + message.Node);

        m_lastMessage = message;

        // draw either player or friend messages
        if(message.Player) {
            RunChatOptions(message);
        } else {
            m_RunBubblesCoroutine = RunChatBubbles(message);
            yield return StartCoroutine(m_RunBubblesCoroutine);
        }

        // if we're not waiting on an option selection, draw the next message
        if(!message.HasOptions) {
            MoveConversation();
        }
    }

    // ------------------------------------------------------------------------
    // actually does the waiting to create delay between messages
    private IEnumerator RunChatBubbles (MessageSO message) {
        if(message == null) {
            Debug.LogError("Message null.");
            yield break;
        }

        //Debug.Log("running chat bubble: " + message.Node);

        // visit all of the messages in this node
        for (int i = 0; i < message.Messages.Length; i++) {
            float t = MaxTimeBetweenMessages;
            if(i == 0 || message.HasOptions) {
                t = 0;
            }
            yield return new WaitForSeconds(t);
            Debug.Log("visited message: " + message.Node + "." + i);

            VisitedMessage(message, i);
        }
    }

    // ------------------------------------------------------------------------
    private void RunChatOptions (MessageSO message) {
        if(message == null) {
            Debug.LogError("Message null.");
            return;
        }
        if(!message.Player) {
            Debug.LogError("Hecked up message data. NPC has chat options.");
            return;
        }
        if(!message.HasOptions) {
            Debug.LogError("Attempting to draw options for message with no options.");
            return;
        }

        Debug.Log("running chat options: " + message.Node);

        for(int i = 0; i < message.Options.Length; i++) {
            VisitedOption(message, i);
        }
    }

    // ------------------------------------------------------------------------
    // selected a chat option
    public void SelectOption (MessageSO message, int selection) {
        if(message == null) {
            Debug.LogError("Message null.");
            return;
        }

        Debug.Log("selected option " + selection + " for message " + message.Node);

        // record in message that this option has been chosen
        message.SelectOption(message.Branch[selection]);

        // run chosen message
        m_RunBubblesCoroutine = RunChatBubbles(message);
        StartCoroutine(m_RunBubblesCoroutine);

        // fire events
        SelectedOption();

        // run next chat
        MoveConversation();
    }

    // ------------------------------------------------------------------------
    private void FinishChat () {
        m_activeChat = null;
        ReachedLeafNode();
    }
}