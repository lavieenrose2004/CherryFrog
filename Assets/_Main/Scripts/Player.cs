using UnityEngine;

public class Player : MonoBehaviour
{
    public int MaxHealth { get; private set; }
    public int CurrHealth { get; private set; }
    public int Speed { get; private set; }
    public int JumpPower { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 10;
        CurrHealth = MaxHealth;

        Speed = 15;
        JumpPower = 60;
    }

    public void EnhanceMaxHealthBy(int amount)
    {
        MaxHealth += amount;
        CurrHealth = MaxHealth;

        Debug.Log("Player's max health increased by " + amount + ". Current health: " + CurrHealth);
    }

    public void EnhanceSpeedBy(int amount)
    {
        Speed += amount;

        Debug.Log("Player's speed increased by " + amount + ". Current speed: " + Speed);
    }

    public void EnhanceJumpPowerBy(int amount)
    {
        JumpPower += amount;

        Debug.Log("Player's jump power increased by " + amount + ". Current jump power: " + JumpPower);
    }

    public void TakeDamage(int damage)
    {
        CurrHealth -= damage;

        if (CurrHealth <= 0)
        {
            CurrHealth = 0;
            Die();
        }

        Debug.Log("Player took " + damage + " damage. Current health: " + CurrHealth);
    }

    public void Heal(int amount)
    {
        CurrHealth += amount;

        if (CurrHealth > MaxHealth)
        {
            CurrHealth = MaxHealth;
        }

        Debug.Log("Player healed for " + amount + " health. Current health: " + CurrHealth);
    }

    private void Die()
    {
        Debug.Log("Player died.");
    }
}
