using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunAttackState : State
{
    private PlayerAnimatorController _animator;
    private GroundChecker _groundChecker;
    private float _valueToMoveY = 0;
    private float _moveSpeed;
    private Weapon _weapon;
    private Mover _mover;

    public PlayerRunAttackState(StateMachine stateMachine, PlayerAnimatorController animator, Mover mover, GroundChecker groundChecker, float moveSpeed, Weapon weapon) : base(stateMachine)
    {
        _animator = animator;
        _mover = mover;
        _groundChecker = groundChecker;
        _moveSpeed = moveSpeed;
        _weapon = weapon;
    }

    public override void Enter()
    {
        _weapon.gameObject.SetActive(true);
        _animator.AttackEnded += EndAttack;
        _animator.StartRunAttackAnimation();
    }

    public override void FixedUpdate()
    {
        if (_groundChecker.IsGrounded)
        {
            _mover.Move(new Vector3(_mover.HorizontalDirection * _moveSpeed, _valueToMoveY));
        }
    }

    public override void Exit()
    {
        _weapon.gameObject.SetActive(false);
        _animator.StopRunAttackAnimation();
        _animator.AttackEnded -= EndAttack;
    }

    public void EndAttack()
    {
        if (_mover.HorizontalDirection == 0)
        {
            StateMachine.SetState<PlayerIdleState>();
        }
        else
        {
            StateMachine.SetState<PlayerMoveState>();
        }
    }
}
