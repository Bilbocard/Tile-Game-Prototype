using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly float _offsetY = 0.32f;
    private PlayerAnimator _playerAnimator;

    private readonly float _playerSpeed = 1.2f;

    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    public IEnumerator MoveTo(Hex targetHex)
    {
        var targetLocation = Utils.AxialToVector2(targetHex) + new Vector2(0f, _offsetY);
        _playerAnimator.AnimateWalk();
        while ((Utils.Vector3ToVector2(transform.position) - targetLocation).sqrMagnitude > float.Epsilon)
        {
            transform.position = Vector2.MoveTowards(Utils.Vector3ToVector2(transform.position), targetLocation,
                Time.deltaTime * _playerSpeed);
            yield return null;
        }

        _playerAnimator.AnimateWalkFinish();
        transform.position = targetLocation;
    }
}