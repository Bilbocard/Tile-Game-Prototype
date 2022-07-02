using UnityEngine;

public abstract class Location : ScriptableObject
{
    [SerializeField] private string locationName;
    [SerializeField] private Sprite sprite;

    public InteractableType InteractableType()
    {
        return global::InteractableType.Location;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public virtual void Interact()
    {
    }
}