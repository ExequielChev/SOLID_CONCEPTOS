
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Move { get; private set; }
    public bool AttackPressed { get; private set; }
    public bool SprintHeld { get; private set; }
    public bool JumpPressed { get; private set; }

    void Update()
    {
        Move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        AttackPressed = Input.GetButtonDown("Fire1");   // click
        SprintHeld = Input.GetKey(KeyCode.LeftShift);   // correr
        JumpPressed = Input.GetButtonDown("Jump");      // espacio
    }

    public void ConsumeAttack() => AttackPressed = false;
    public void ConsumeJump() => JumpPressed = false;
}
