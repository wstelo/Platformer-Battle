using UnityEngine;

public class PlayerAnimationData : MonoBehaviour
{
    public static readonly int IsIdle = Animator.StringToHash(nameof(IsIdle));
    public static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
    public static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
    public static readonly int IsIdleAttack = Animator.StringToHash(nameof(IsIdleAttack));
    public static readonly int IsRunAttack = Animator.StringToHash(nameof(IsRunAttack));
}
