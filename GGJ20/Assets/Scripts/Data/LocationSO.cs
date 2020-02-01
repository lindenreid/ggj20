using UnityEngine;

[CreateAssetMenu(fileName = "Location", menuName = "GreenTea/ScriptableObjects/Location", order = 1)]
public class LocationSO : ScriptableObject 
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public string Name;
    public Sprite Icon;
    public Sprite Background;
}