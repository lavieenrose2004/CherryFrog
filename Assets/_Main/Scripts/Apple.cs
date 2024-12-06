public class Apple : SpecialItem
{
    public override void ApplyEffect(Player player)
    {
        player.EnhanceMaxHealthBy(effectStrength);
    }
}
