using System.Collections;
using UnityEngine;

public class Spike : Trap
{
    [SerializeField] private int bleedDamage;
    [SerializeField] private int bleedDuration;
    [SerializeField] private int bleedInterval;

    public event System.Action OnBleed;

    public override void ApplyEffect(Player player)
    {
        player.TakeDamage(damage);
        player.Bleed(bleedDamage, bleedDuration, bleedInterval);
    }
}
