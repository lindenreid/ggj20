using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "GreenTea/ScriptableObjects/Item", order = 1)]
public class ItemSO : ScriptableObject 
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public string Name;
    public string Description;
    public Sprite Icon;
    public bool CanTake;
}