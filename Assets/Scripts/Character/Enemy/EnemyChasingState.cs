using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyChasingState : State
{
    private EnemyAnimatorController _animator;
    private EnemyAreaViewer _areaViewer;
    private Collider2D _currentTarget;
    private Mover _mover;
    private float _distanceToTarget = 3f;
    private bool _isCome = false;
    private float _moveSpeed;
    private Vector3 _direction;

    public EnemyChasingState(StateMachine stateMachine, EnemyAnimatorController animator , EnemyAreaViewer enemyViewer, Mover mover, float moveSpeed) : base(stateMachine)
    {
        _areaViewer = enemyViewer;
        _moveSpeed = moveSpeed;
        _animator = animator;
        _mover = mover;
    }

    public override void Enter()
    {
        _currentTarget = _areaViewer.GetTarget();
        _animator.StartRunAnimation();
    }

    public override void Update()
    {
        _direction = new Vector3(_currentTarget.transform.position.x - _mover.transform.position.x, 0);

        if (_areaViewer.CurrentTarget)
        {
            if (_mover.transform.position.IsEnoughClose(_currentTarget.transform.position, _distanceToTarget))
            {
                _isCome = true;
                _mover.ResetDirection();
                 StateMachine.SetState<EnemyAttackState>();
            }
            else
            {
                _isCome = false;
            }
        }
        else
        {
            StateMachine.SetState<EnemyCheckAreaState>();
        }
    }

    public override void FixedUpdate()
    {
        if (_isCome == false)
        {
            if (_direction.x > 0)
            {
                _direction.x = 1;
            }
            else if (_direction.x < 0)
            {
                _direction.x = -1;
            }

            _mover.Move(_direction, _moveSpeed);
        }
    }

    public override void Exit()
    {
        _animator.StopRunAnimation();
    }
}
