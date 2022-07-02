using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private static readonly int PlayerWalk = Animator.StringToHash("PlayerStartWalk");
    private static readonly int PlayerIdle = Animator.StringToHash("PlayerIdle");
    private static readonly int FinishWalk = Animator.StringToHash("FinishWalk");
    private Animator _animator;
    private bool _walking;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimateWalk()
    {
        if (_walking) return;
        _animator.Play(PlayerWalk);
        _walking = true;
    }

    public void AnimateIdle()
    {
        _walking = false;
        _animator.Play(PlayerIdle);
    }

    public void AnimateWalkFinish()
    {
        _walking = false;
        _animator.SetTrigger(FinishWalk);
    }
}