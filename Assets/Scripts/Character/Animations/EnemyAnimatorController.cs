using UnityEngine;
using System;

public class EnemyAnimatorController : MonoBehaviour
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

    public void StartAttackAnimation()
    {
        _animator.SetBool(AnimationData.IsAttack, true);
    }

    public void StopIdleAnimation()
    {
        _animator.SetBool(AnimationData.IsIdle, false);
    }

    public void StopRunAnimation()
    {
        _animator.SetBool(AnimationData.IsRun, false);
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
