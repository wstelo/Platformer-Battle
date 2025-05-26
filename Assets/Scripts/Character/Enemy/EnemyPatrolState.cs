using UnityEngine;

public class EnemyPatrolState : State
{
    private PointCollector _patrolPointsCollector;
    private EnemyAnimatorController _animator;
    private EnemyAreaViewer _areaViewer;
    private Transform _currentTarget;
    private Mover _mover;
    private float _distanceToTarget = 1f;
    private int _currentTargetIndex = 0;
    private bool _isCome = false;
    private float _moveSpeed;
    private Vector3 _direction;

    public EnemyPatrolState(StateMachine stateMachine, PointCollector patrolPoints, EnemyAnimatorController animator, Mover mover, float moveSpeed, EnemyAreaViewer areaViewer) : base(stateMachine)
    {
        _patrolPointsCollector = patrolPoints;
        _areaViewer = areaViewer;
        _moveSpeed = moveSpeed;
        _animator = animator;
        _mover = mover;
    }

    public override void Enter()
    {
        _isCome = false;
        _animator.StartRunAnimation();
        _currentTarget = GetNextPoint();
        _direction = new Vector3(_currentTarget.transform.position.x - _mover.transform.position.x,0);
        _mover.SetDirection(_direction.x);
    }

    public override void Update()
    {
        if (_mover.transform.position.IsEnoughClose(_currentTarget.position, _distanceToTarget))
        {
            _isCome = true;
            _mover.ResetDirection();
            StateMachine.SetState<EnemyCheckAreaState>();
        }

        if (_areaViewer.CurrentTarget)
        {
            StateMachine.SetState<EnemyChasingState>();
        }
    }

    public override void FixedUpdate()
    {
        if(_isCome == false)
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

    private Transform GetNextPoint()
    {
        _currentTargetIndex = (++_currentTargetIndex) % _patrolPointsCollector.TargetPoints.Count;

        return _patrolPointsCollector.TargetPoints[_currentTargetIndex];
    }
}
