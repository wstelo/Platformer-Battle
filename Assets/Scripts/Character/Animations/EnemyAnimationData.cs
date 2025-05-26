using UnityEngine;

public class EnemyAnimationData : MonoBehaviour
{
    public static readonly int IsIdle = Animator.StringToHash(nameof(IsIdle));
    public static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
    public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
}
