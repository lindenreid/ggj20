using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ClickDetection : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public Navigation Navigation;
    
    private bool m_enabled;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    void Awake () {
        m_enabled = true;
        foreach(UIScreen screen in Navigation.UIScreens) {
            screen.Opened += HandleUIOpened;
            screen.Closed += HandleUIClosed;
        }
    }

    // ------------------------------------------------------------------------
    void OnMouseUpAsButton() {
        if(m_enabled) {
            OnClick();
        }
    }

    // ------------------------------------------------------------------------
    protected virtual void OnClick () {
        Debug.LogError("OnClick not implemented.");
    }

    // ------------------------------------------------------------------------
    private void HandleUIOpened () {
        m_enabled = false;
    }

    // ------------------------------------------------------------------------
    private void HandleUIClosed () {
        m_enabled = true;
    }
}
