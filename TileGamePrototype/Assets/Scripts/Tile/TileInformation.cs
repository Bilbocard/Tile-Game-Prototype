using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileInformation
{
    public TileBase tileBase;
    public Location location;
    public Creature creature;

    public TileInformation()
    {
        tileBase = null;
        location = null;
        creature = null;
    }
}
