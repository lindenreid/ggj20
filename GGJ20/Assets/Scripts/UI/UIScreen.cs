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
        if(Opened != null)
            Opened();
    }

    // ------------------------------------------------------------------------
    protected virtual void OnDisable () {
        if(Closed != null)
            Closed();
    }

    // ------------------------------------------------------------------------
    protected void FireOpened () {
        if(Opened != null)
            Opened();
    }

    // ------------------------------------------------------------------------
    protected void FireClosed () {
        if(Closed != null)
            Closed();
    }
}