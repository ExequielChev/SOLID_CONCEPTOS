
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    int hp; PlayerAnimator pa;

    void Awake() { hp = maxHealth; pa = GetComponent<PlayerAnimator>(); }

    public void TakeDamage(int dmg)
    {
        if (hp <= 0) return;
        hp = Mathf.Max(0, hp - dmg);
        if (hp == 0) pa?.PlayDeath();
    }
}
