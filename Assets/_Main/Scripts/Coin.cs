using UnityEngine;

public class Coin : Item {
    public override void OnPickUp(Player player)
    {
        Debug.Log("Player picked up a coin!");
        Destroy(gameObject);
    }
}
