using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract void OnPickUp(Player player);
}
