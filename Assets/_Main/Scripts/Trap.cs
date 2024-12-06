using System.Collections;
using UnityEngine;

public abstract class Trap : MonoBehaviour, ISpecialEffect
{
    [SerializeField] protected int damage;

    public virtual void ApplyEffect(Player player)
    {
        player.TakeDamage(damage);
    }
}
