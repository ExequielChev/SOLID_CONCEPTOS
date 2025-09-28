using UnityEngine;

public class EmptyHandsAttack : MonoBehaviour, IAttack
{
    [SerializeField] float range = 1.2f;
    [SerializeField] float radius = 0.6f;
    [SerializeField] int damage = 20;
    [SerializeField] LayerMask hitMask = ~0; // todo por defecto

    public void Attack()
    {
        // chequear frente del player con un "golpe" simple
        Vector3 origin = transform.position + transform.forward * range;
        var hits = Physics.OverlapSphere(origin, radius, hitMask, QueryTriggerInteraction.Ignore);
        foreach (var h in hits)
        {
            var health = h.GetComponent<PlayerHealth>();
            if (health) health.TakeDamage(damage);
        }
        Debug.Log("[EmptyHandsAttack] golpe lanzado");
    }

    // Gizmo para ver el área del golpe en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 origin = transform.position + transform.forward * range;
        Gizmos.DrawWireSphere(origin, radius);
    }
}
