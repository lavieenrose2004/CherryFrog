using System.Collections;
using UnityEngine;

public class Spike : Trap
{
    [SerializeField] private int bleedDamage;
    [SerializeField] private int bleedDuration;

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
            yield return new WaitForSeconds(2);
            player.TakeDamage(bleedDamage);
            elapsedTime++;
        }
    }
}
