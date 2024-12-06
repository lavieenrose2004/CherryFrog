using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public virtual void OnPickUp(Player player) {
        Debug.Log($"Player picked up {GetType().Name}");
        Destroy(gameObject);
    }
}

public abstract class SpecialItem : Item, ISpecialEffect
{
    [SerializeField] protected int effectStrength;

    public abstract void ApplyEffect(Player player);
}
