using System.Collections;
using UnityEngine;

public class Spike : Trap
{
    [SerializeField] private int bleedDamage;
    [SerializeField] private int bleedDuration;
    [SerializeField] private int bleedInterval;

    public override void ApplyEffect(Player player)
    {
        player.TakeDamage(damage);
        StartCoroutine(Bleed(player));
    }

    IEnumerator Bleed(Player player)
    {
        int elapsedTime = 0;
        while (elapsedTime < bleedDuration)
        {
            yield return new WaitForSeconds(bleedInterval);
            player.TakeDamage(bleedDamage);
            elapsedTime += bleedInterval;
        }
    }
}
