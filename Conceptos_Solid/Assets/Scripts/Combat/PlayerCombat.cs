using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    IAttack attack;
    PlayerInput input;

    public void SetAttack(IAttack a) => attack = a; // inyección

    void Awake() { input = GetComponent<PlayerInput>(); }

    void Update()
    {
        if (input.AttackPressed) attack?.Attack();
    }
}
