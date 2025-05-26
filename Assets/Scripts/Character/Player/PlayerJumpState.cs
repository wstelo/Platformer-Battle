using UnityEngine;

public class PlayerJumpState : State
{
    private PlayerAnimatorController _animator;
    private GroundChecker _groundChecker;
    private float _jumpForceHorizontal;
    private InputService _inputService;
    private float _jumpForceVertical;
    private Rigidbody2D _rigidBody;
    private Mover _mover;

    public PlayerJumpState(StateMachine stateMachine, PlayerAnimatorController animator, Rigidbody2D rigidBody, float jumpForceVertical, float jumpForceHorizontal, Mover mover, GroundChecker groundChecker, InputService inputService) : base(stateMachine)
    {
        _animator = animator;
        _rigidBody = rigidBody;
        _jumpForceVertical = jumpForceVertical;
        _jumpForceHorizontal = jumpForceHorizontal;
        _mover = mover;
        _groundChecker = groundChecker;
        _inputService = inputService;
    }

    public override void Enter()
    {
        _animator.StartJumpAnimation();
    }

    public override void Update()
    {
        if(_groundChecker.IsGrounded && _inputService.IsJump == false )
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

    public override void FixedUpdate()
    {
        if (_groundChecker.IsGrounded && _inputService.IsJump)
        {
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.AddForce(new Vector2(_mover.HorizontalDirection * _jumpForceHorizontal, _jumpForceVertical),ForceMode2D.Impulse);
        }
    }

    public override void Exit()
    {
        _animator.StopJumpAnimation();
    }
}
