using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public virtual void OnPickUp(Player player) {
        Debug.Log($"Player picked up {this.GetType().Name}");
        Destroy(gameObject);
    }
}

public abstract class SpecialItem : Item, ISpecialEffect
{
    public abstract void ApplyEffect(Player player);
}
