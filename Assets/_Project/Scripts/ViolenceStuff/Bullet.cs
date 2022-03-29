using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var damageable = collision.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
