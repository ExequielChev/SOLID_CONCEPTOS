
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    Animator anim; PlayerLocomotion loc; PlayerInput input;

    static readonly int Speed = Animator.StringToHash("Speed");
    static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    static readonly int Attack = Animator.StringToHash("Attack");
    static readonly int Jump = Animator.StringToHash("Jump");
    static readonly int Die = Animator.StringToHash("Die");

    void Awake()
    {
        anim = GetComponent<Animator>();
        loc  = GetComponent<PlayerLocomotion>();
        input= GetComponent<PlayerInput>();
    }

    void Update()
    {
        anim.SetFloat(Speed,  loc?.PlanarSpeed ?? 0f);
        anim.SetBool(IsGrounded, loc?.IsGrounded ?? true);

        if (input.AttackPressed) { anim.SetTrigger(Attack); input.ConsumeAttack(); }
        if (input.JumpPressed && (loc?.IsGrounded ?? false)) { anim.SetTrigger(Jump); input.ConsumeJump(); }
    }

    public void PlayDeath() => anim.SetTrigger(Die);
}

