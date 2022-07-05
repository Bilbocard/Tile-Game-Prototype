using System;
using UnityEngine;

public interface IMovement
{
    public event Action<Hex> StartMove;
    public event Action<Hex> EndMove;

    public void Move(Hex targetHex);
}