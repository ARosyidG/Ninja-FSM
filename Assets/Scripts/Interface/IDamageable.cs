using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int amount, GameObject from);
    bool IsDead { get; }
}