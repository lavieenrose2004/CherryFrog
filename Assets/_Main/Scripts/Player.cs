using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int MaxHealth { get; private set; }
    public int CurrHealth { get; private set; }
    public int Speed { get; private set; }
    public int JumpPower { get; private set; }
    public int CherryCount { get; private set; }

    [SerializeField] int speed = 15;
    [SerializeField] int jumpPower = 60;

    bool isInvulnerable;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 10;
        CurrHealth = MaxHealth;

        Speed = speed;
        JumpPower = jumpPower;

        playerController = GetComponentInChildren<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        if (item != null) item.OnPickUp(this);

        ISpecialEffect specialEffect = other.GetComponent<ISpecialEffect>();

        if (specialEffect != null)
        {
            specialEffect.ApplyEffect(this);
        }
    }

    public void AddCherry()
    {
        CherryCount++;
    }

    public void EnhanceMaxHealthBy(int amount)
    {
        MaxHealth += amount;
        CurrHealth = MaxHealth;

        Debug.Log("Player's max health increased by " + amount + ". Current health: " + CurrHealth);
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

    public void TakeDamage(int damage)
    {
        if (isInvulnerable) return;

        CurrHealth -= damage;
        playerController.PlayHurtAnim();
        StartCoroutine(Invulnerability());

        if (CurrHealth <= 0)
        {
            CurrHealth = 0;
            StartCoroutine(Die());
        }

        Debug.Log("Player took " + damage + " damage. Current health: " + CurrHealth);
    }

    IEnumerator Die()
    {
        playerController.PlayDeadAnim();

        yield return new WaitForSeconds(0.3f);
        playerController.gameObject.SetActive(false);
        Debug.Log("Player died.");
    }

    IEnumerator Invulnerability()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(0.5f);
        isInvulnerable = false;
    }

}
