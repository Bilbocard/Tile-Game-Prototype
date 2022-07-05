using System;
using UnityEngine;

public class BounceAnimator : MonoBehaviour
{
    private static readonly int PlayerWalk = Animator.StringToHash("PlayerStartWalk");
    private static readonly int PlayerIdle = Animator.StringToHash("PlayerIdle");
    private static readonly int FinishWalk = Animator.StringToHash("FinishWalk");
    private Animator _animator;
    private IMovement _movement;
    private bool _walking;
    private Action<Hex> _walkAction;
    private Action<Hex> _walkFinishAction;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<IMovement>();
        _walkAction = _ => Bounce();
        _walkFinishAction = _ => BounceFinish();
    }

    private void Bounce()
    {
        if (_walking) return;
        _animator.Play(PlayerWalk);
        _walking = true;
    }

    private void AnimateIdle()
    {
        _walking = false;
        _animator.Play(PlayerIdle);
    }

    private void BounceFinish()
    {
        _walking = false;
        _animator.SetTrigger(FinishWalk);
    }

    private void OnEnable()
    {
        if (_movement != null) _movement.StartMove += _walkAction;
        if (_movement != null) _movement.EndMove += _walkFinishAction;
    }

    private void OnDisable()
    {
        if (_movement != null) _movement.StartMove -= _walkAction;
        if (_movement != null) _movement.EndMove -= _walkFinishAction;
    }
}