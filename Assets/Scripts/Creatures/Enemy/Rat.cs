using UnityEngine;

[CreateAssetMenu(menuName = "Hexplorer/Creatures/Enemy/New Rat", fileName = "New Rat")]
public class Rat : Enemy
{
    public override void Interact()
    {
        Debug.Log("We have interacted with the rat");
    }
}