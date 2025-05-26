using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleAttackState : State
{
    private PlayerAnimatorController _animator;
    private Weapon _weapon;
    private Mover _mover;

    public PlayerIdleAttackState(StateMachine stateMachine, PlayerAnimatorController animator, Mover mover, Weapon weapon) : base(stateMachine)
    {
        _animator = animator;
        _mover = mover;
        _weapon = weapon;
    }

    public override void Enter()
    {
        _weapon.gameObject.SetActive(true);
        _animator.AttackEnded += EndAttack;
        _animator.StartIdleAttackAnimation();
    }

    public override void Exit()
    {
        _weapon.gameObject.SetActive(false);
        _animator.StopIdleAttackAnimation();
        _animator.AttackEnded -= EndAttack;
    }

    public void EndAttack()
    {
        if(_mover.HorizontalDirection == 0)
        {
            StateMachine.SetState<PlayerIdleState>();
        }
        else
        {
            StateMachine.SetState<PlayerMoveState>();
        }
    }
}
