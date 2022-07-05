using System;
using System.Collections;using UnityEngine;

public class ConstantMovement : MonoBehaviour, IMovement
{
    public event Action<Hex> StartMove;
    public event Action<Hex> EndMove;
    
    [SerializeField] private float offsetY = 0.32f;
    [SerializeField] private float playerSpeed = 1.2f;
    public void Move(Hex targetHex)
    {
        StartCoroutine(OnMove(targetHex));
    }

    private IEnumerator OnMove(Hex targetHex)
    {
        var targetLocation = Utils.AxialToVector2(targetHex) + new Vector2(0f, offsetY);
        StartMove?.Invoke(targetHex);
        while ((Utils.Vector3ToVector2(transform.position) - targetLocation).sqrMagnitude > float.Epsilon)
        {
            transform.position = Vector2.MoveTowards(Utils.Vector3ToVector2(transform.position), targetLocation,
                Time.deltaTime * playerSpeed);
            yield return null;
        }
        EndMove?.Invoke(targetHex);
        transform.position = targetLocation;
    }
}