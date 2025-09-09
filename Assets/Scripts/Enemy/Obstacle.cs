using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Collider2D Collider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable == null) return;
        damageable.TakeDamage(10, gameObject);
    }
}
