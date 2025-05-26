using UnityEngine;

public class EnemyCheckAreaState : State
{
    private EnemyAnimatorController _animator;
    private EnemyAreaViewer _areaViewer;
    private Rotator _rotator;
    private float _remainingTimeToNextState;
    private float _remainingTimeToRotate;
    private float _timeToRotate = 0.5f;
    private float _timeToIdle;

    public EnemyCheckAreaState(StateMachine stateMachine, EnemyAnimatorController animator, float timeToIdle, Rotator rotator, EnemyAreaViewer enemyTargetCollector) : base(stateMachine)
    {
        _animator = animator;
        _timeToIdle = timeToIdle;
        _rotator = rotator;
        _areaViewer = enemyTargetCollector;
    }

    public override void Enter()
    {
        _remainingTimeToRotate = _timeToRotate;
        _remainingTimeToNextState = _timeToIdle;
        _animator.StartIdleAnimation();
    }

    public override void Update()
    {
        _remainingTimeToNextState -= Time.deltaTime;
        _remainingTimeToRotate -= Time.deltaTime;

        if (_areaViewer.CurrentTarget)
        {
            StateMachine.SetState<EnemyChasingState>();
        }

        if (_remainingTimeToRotate < 0)
        {
            _rotator.RotateCharacter();
            _remainingTimeToRotate = _timeToRotate;
        }

        if(_remainingTimeToNextState < 0)
        {
            StateMachine.SetState<EnemyPatrolState>();
        }
    }

    public override void Exit()
    {
        _animator.StopIdleAnimation();
    }
}
