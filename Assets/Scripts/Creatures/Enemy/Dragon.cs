using UnityEngine;

[CreateAssetMenu(menuName = "Hexplorer/Creatures/Enemy/New Dragon", fileName = "New Dragon")]
public class Dragon : Enemy
{
    public override void Interact()
    {
        Debug.Log("We have interacted with the dragon");
    }
}