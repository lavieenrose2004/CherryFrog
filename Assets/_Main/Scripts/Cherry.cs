public class Cherry : Item
{
    public override void OnPickUp(Player player)
    {
        player.AddCherry();
        base.OnPickUp(player);
    }
}