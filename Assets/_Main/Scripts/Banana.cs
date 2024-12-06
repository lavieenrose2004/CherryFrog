public class Banana : SpecialItem
{
    public override void OnPickUp(Player player)
    {
        if (player.CurrHealth == player.MaxHealth) return;
        base.OnPickUp(player);
    }

    public override void ApplyEffect(Player player)
    {
        if (player.CurrHealth == player.MaxHealth) return;
        
        player.Heal(effectStrength);
    }
}
