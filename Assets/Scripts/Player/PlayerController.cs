using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerAnimator _playerAnimator;
    private float _offsetY = 0.32f;
    private Hex _currentHex;
    private float _playerSpeed = 1.2f;

    private void Awake()
    {
        _currentHex = Utils.CoordinateToWorldHex(transform.position);
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ActionManager.Instance.RequestMove(this, Utils.MouseToWorldHex());
        }
    }

    public IEnumerator Move(Hex targetHex)
    {
        SETTINGS.PlayerCanMove = false;
        Vector2 targetLocation = Utils.AxialToVector2(targetHex) + new Vector2(0f, _offsetY);
        _playerAnimator.AnimateWalk();
        while ((Utils.Vector3ToVector2(transform.position) - targetLocation).sqrMagnitude > float.Epsilon)
        {
            transform.position = Vector2.MoveTowards(Utils.Vector3ToVector2(transform.position), targetLocation, Time.deltaTime * _playerSpeed);
            yield return null;
        }
        _playerAnimator.AnimateWalkFinish();
        transform.position = targetLocation;
        _currentHex = targetHex;
        yield return new WaitForSeconds(0.3f);
        yield return AdventureManager.Instance.MoveToTile(targetHex);
        SETTINGS.PlayerCanMove = true;
        yield return null;
    }

    public Hex GetCurrentHex()
    {
        return _currentHex;
    }
}
