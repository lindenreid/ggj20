using UnityEngine;

public class UIScreen : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public delegate void OpenDelegate();
    public event OpenDelegate Opened;

    public delegate void CloseDelegate();
    public event CloseDelegate Closed;

    // ------------------------------------------------------------------------
    protected virtual void OnEnable () {
        Opened();
    }

    // ------------------------------------------------------------------------
    protected virtual void OnDisable () {
        Closed();
    }

    // ------------------------------------------------------------------------
    protected void FireOpened () {
        Opened();
    }

    // ------------------------------------------------------------------------
    protected void FireClosed () {
        Closed();
    }
}