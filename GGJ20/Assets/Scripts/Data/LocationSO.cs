using UnityEngine;

public enum LocationType {
    Grave = 0,
    Forest = 1
}

[CreateAssetMenu(fileName = "Location", menuName = "GreenTea/ScriptableObjects/Location", order = 1)]
public class LocationSO : ScriptableObject 
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public string Name;
    public LocationType LocationType;
    public Sprite Icon;
    public Sprite Background;
}