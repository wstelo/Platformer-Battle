using UnityEngine;

public class PlayerIdleState : State
{
    private PlayerAnimatorController _animator;
    private GroundChecker _groundChecker;
    private InputService _inputService;
    private Mover _mover;

    public PlayerIdleState(StateMachine stateMachine, PlayerAnimatorController animator, Mover mover, GroundChecker groundChecker, InputService inputService) : base(stateMachine)
    {
        _animator = animator;
        _mover = mover;
        _groundChecker = groundChecker;
        _inputService = inputService;
    }

    public override void Enter()
    {
        _animator.StartIdleAnimation();
        _inputService.Attacked += ChangeToIdleAttackState;
    }

    public override void Update()
    {
        if (_mover.HorizontalDirection != 0)
        {
            StateMachine.SetState<PlayerMoveState>();
        }

        if (_groundChecker.IsGrounded && _inputService.IsJump && _mover.HorizontalDirection == 0)
        {
            StateMachine.SetState<PlayerJumpState>();
        }
    }

    public override void Exit()
    {
        _animator.StopIdleAnimation();
        _inputService.Attacked -= ChangeToIdleAttackState;
    }

    private void ChangeToIdleAttackState()
    {
        StateMachine.SetState<PlayerIdleAttackState>();
    }
}
