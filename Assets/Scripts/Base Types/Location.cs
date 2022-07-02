using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Location : ScriptableObject
{
    [SerializeField] private string locationName;
    [SerializeField] private Sprite sprite;

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
