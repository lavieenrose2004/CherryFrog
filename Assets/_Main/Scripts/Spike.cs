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
        StartCoroutine(Bleed(player));
    }

    IEnumerator Bleed(Player player)
    {
        int elapsedTime = 0;
        while (elapsedTime < bleedDuration)
        {
            if (player.CurrHealth <= 0) break;

            yield return new WaitForSeconds(bleedInterval);

            player.TakeDamage(bleedDamage);
            OnBleed?.Invoke();

            elapsedTime += bleedInterval;
        }
    }
}
