using UnityEngine;

[RequireComponent(typeof(PlayerCombat))]
public class ActionInstaller : MonoBehaviour
{
    [SerializeField] MonoBehaviour attackBehaviour; // debe implementar IAttack
    void Awake()
    {
        var combat = GetComponent<PlayerCombat>();
        if (attackBehaviour is IAttack a) combat.SetAttack(a);
        else Debug.LogError("ActionInstaller: el componente asignado no implementa IAttack.");
    }
}
