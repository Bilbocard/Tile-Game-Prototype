using System;
using UnityEngine;

public class InstantMovement : MonoBehaviour, IMovement
{
    public event Action<Hex> StartMove;
    public event Action<Hex> EndMove;
    public void Move(Hex targetHex)
    {
        StartMove?.Invoke(targetHex);
        Vector2 target = Utils.AxialToVector2(targetHex);
        transform.position = target;
        EndMove?.Invoke(targetHex);
    }
}