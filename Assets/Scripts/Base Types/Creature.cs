using UnityEngine;

public abstract class Creature : ScriptableObject
{
    [SerializeField] private string creatureName;
    [SerializeField] private Sprite sprite;

    public virtual InteractableType InteractableType()
    {
        return global::InteractableType.None;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public virtual void Interact()
    {
    }
}