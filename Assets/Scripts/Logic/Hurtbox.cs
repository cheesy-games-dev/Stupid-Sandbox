using UnityEngine;

public class Hurtbox : MonoBehaviour, IDamageable
{
    public Health health;

    public void TakeDamage(float damage)
    {
        health.TakeDamage(damage);
    }

    void Start()
    {
        if (!health)
        {
            health = GetComponentInParent<Health>();
        }
    }
}
