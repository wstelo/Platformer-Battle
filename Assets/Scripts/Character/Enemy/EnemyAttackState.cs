public class EnemyAttackState : State
{
    private EnemyAnimatorController _animator;
    private Weapon _weapon;

    public EnemyAttackState(StateMachine stateMachine, EnemyAnimatorController animator, Weapon weapon) : base(stateMachine)
    {
        _animator = animator;
        _weapon = weapon;
    }

    public override void Enter()
    {
        _weapon.gameObject.SetActive(true);
        _animator.AttackEnded += EndAttack;
        _animator.StartAttackAnimation();
    }

    public override void Exit()
    {
        _weapon.gameObject.SetActive(false);
        _animator.StopAttackAnimation();
        _animator.AttackEnded -= EndAttack;
    }

    public void EndAttack()
    {
        StateMachine.SetState<EnemyCheckAreaState>();
    }
}
