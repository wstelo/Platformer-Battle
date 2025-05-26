using UnityEngine;

public class PlayerMoveState : State
{
    private PlayerAnimatorController _animator;
    private GroundChecker _groundChecker;
    private InputService _inputService;
    private float _valueToMoveY = 0;
    private float _moveSpeed;
    private Mover _mover;

    public PlayerMoveState(StateMachine stateMachine, PlayerAnimatorController animator, float moveSpeed, Mover mover, GroundChecker groundChecker, InputService inputService) : base(stateMachine)
    {
        _animator = animator;
        _moveSpeed = moveSpeed;
        _mover = mover;
        _groundChecker = groundChecker;
        _inputService = inputService;
    }

    public override void Enter()
    {
        _inputService.Attacked += ChangeToRunAttackState;
        _animator.StartRunAnimation();
    }

    public override void Update()
    {
        if(_groundChecker.IsGrounded && _inputService.IsJump)
        {
            StateMachine.SetState<PlayerJumpState>();
        }

        if(_mover.HorizontalDirection == 0)
        {
            StateMachine.SetState<PlayerIdleState>();
        }        
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
        _animator.StopRunAnimation();
        _inputService.Attacked -= ChangeToRunAttackState;
    }

    private void ChangeToRunAttackState()
    {
        StateMachine.SetState<PlayerRunAttackState>();
    }
}
