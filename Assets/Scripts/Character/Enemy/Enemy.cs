using System;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(EnemyAnimatorController))]
[RequireComponent (typeof(Rotator), typeof(Health), typeof(EnemyAreaViewer))]

public class Enemy : Character
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _timeToIdle = 3f;
    [SerializeField] private Weapon _weapon;

    private PointCollector _patrolPointsCollector;
    private EnemyAnimatorController _animator;
    private EnemyAreaViewer _areaViewer;
    private StateMachine _stateMachine;
    private Rotator _rotator;
    private Mover _mover;

    private void Awake()
    {
        _animator = GetComponent<EnemyAnimatorController>();
        _areaViewer = GetComponent<EnemyAreaViewer>();
        _stateMachine = new StateMachine();
        _rotator = GetComponent<Rotator>();
        _mover = GetComponent<Mover>();
    }

    private void Start()
    {
        _stateMachine.AddState(new EnemyAttackState(_stateMachine, _animator, _weapon));
        _stateMachine.AddState(new EnemyChasingState(_stateMachine, _animator,_areaViewer, _mover, _moveSpeed));
        _stateMachine.AddState(new EnemyPatrolState(_stateMachine, _patrolPointsCollector, _animator, _mover, _moveSpeed, _areaViewer));
        _stateMachine.AddState(new EnemyCheckAreaState(_stateMachine,_animator,_timeToIdle, _rotator, _areaViewer));
        _stateMachine.SetState<EnemyPatrolState>();
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    public void Initialize(PointCollector points)
    {
        _patrolPointsCollector = points;
    }
}
