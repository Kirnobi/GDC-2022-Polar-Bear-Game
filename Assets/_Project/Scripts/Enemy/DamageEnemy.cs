using UnityEngine;

public class DamageEnemy : MonoBehaviour, IDamageable
{
    [SerializeField, Range(10, 50)] private float maxHealth;

    private float _health;

    private void Awake()
    {
        _health = maxHealth;
    }

    public float GetHealth() => _health;


    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health == 0)
        {
            print("Died");
            Destroy(gameObject);
        }
    }
}
