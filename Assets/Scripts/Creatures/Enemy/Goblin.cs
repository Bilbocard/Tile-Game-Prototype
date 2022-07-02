using UnityEngine;

[CreateAssetMenu(menuName = "Hexplorer/Creatures/Enemy/New Goblin", fileName = "New Goblin")]
public class Goblin : Enemy
{
    public override void Interact()
    {
        Debug.Log("We have interacted with the goblin");
    }
}