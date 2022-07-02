using UnityEngine;

[CreateAssetMenu(menuName = "Hexplorer/Creatures/Enemy/New Wolf", fileName = "New Wolf")]
public class Wolf : Enemy
{
    public override void Interact()
    {
        Debug.Log("We have interacted with the wolf");
    }
}