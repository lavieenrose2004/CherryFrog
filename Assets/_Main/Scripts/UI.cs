using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TMP_Text healthText;

    void Update()
    {
        healthText.text = $"Health: {player.CurrHealth} / {player.MaxHealth}";
    }
}
