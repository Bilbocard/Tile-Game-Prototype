using UnityEngine;

[CreateAssetMenu(menuName = "Hexplorer/Locations/Tavern", fileName = "New Tavern")]
public class Tavern : Location
{
    public override void Interact()
    {
        Debug.Log("Interacted with Tavern");
    }
}