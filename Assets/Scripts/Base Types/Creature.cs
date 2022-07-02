using UnityEngine;

public abstract class Creature : ScriptableObject
{
    [SerializeField] private string creatureName;
    [SerializeField] private Sprite sprite;

    public virtual CreatureType CreatureType()
    {
        return global::CreatureType.None;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public virtual void Interact()
    {
        
    }

    public virtual void OnComplete()
    {
        
    }

}
