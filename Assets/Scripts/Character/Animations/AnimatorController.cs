using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    public event Action AttackEnded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartIdleAnimation()
    {
        _animator.SetBool(AnimationData.IsIdle, true);
    }

    public void StartRunAnimation()
    {
        _animator.SetBool(AnimationData.IsRun, true);
    }

    public void StartJumpAnimation()
    {
        _animator.SetBool(AnimationData.IsJump, true);
    }

    public void StartAttackAnimation()
    {
        _animator.SetBool(AnimationData.IsAttack, true);
    }

    public void StartIdleAttackAnimation()
    {
     _animator.SetBool(AnimationData.IsIdleAttack, true);   
    }

    public void StartRunAttackAnimation()
    {
        _animator.SetBool(AnimationData.IsRunAttack, true);
    }

    public void StopIdleAnimation()
    {
        _animator.SetBool(AnimationData.IsIdle, false);
    }

    public void StopRunAnimation()
    {
        _animator.SetBool(AnimationData.IsRun, false);
    }

    public void StopJumpAnimation()
    {
        _animator.SetBool(AnimationData.IsJump, false);
    }

    public void StopIdleAttackAnimation()
    {
        _animator.SetBool(AnimationData.IsIdleAttack, false);
    }

    public void StopRunAttackAnimation()
    {
        _animator.SetBool(AnimationData.IsRunAttack, false);
    }

    public void StopAttackAnimation()
    {
        _animator.SetBool(AnimationData.IsAttack, false);
    }

    public void AttackAnimationEnded()
    {
        AttackEnded?.Invoke();
    }
}
