
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField] float walkSpeed = 2.2f, runSpeed = 5f, gravity = -25f, jumpHeight = 1.6f;
    [SerializeField] Transform cameraPivot;
    CharacterController cc; PlayerInput input; Transform cam;
    float vy;
    public float PlanarSpeed { get; private set; }
    public bool IsGrounded => cc.isGrounded;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
        cam = cameraPivot ? cameraPivot : (Camera.main ? Camera.main.transform : transform);
    }

    void Update()
    {
        Vector3 fwd = Vector3.Scale(cam.forward, new Vector3(1,0,1)).normalized;
        Vector3 right = cam.right;
        Vector3 dir = (fwd * input.Move.y + right * input.Move.x).normalized;

        if (dir.sqrMagnitude > 0.0001f)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 12f * Time.deltaTime);

        float speed = input.SprintHeld ? runSpeed : walkSpeed;
        Vector3 planar = dir * speed;

        if (cc.isGrounded)
        {
            if (vy < 0) vy = -2f;
            if (input.JumpPressed)
            {
                vy = Mathf.Sqrt(jumpHeight * -2f * gravity);
                input.ConsumeJump();
            }
        }
        vy += gravity * Time.deltaTime;

        cc.Move((planar + Vector3.up * vy) * Time.deltaTime);

        PlanarSpeed = new Vector3(cc.velocity.x, 0, cc.velocity.z).magnitude;
    }
}
