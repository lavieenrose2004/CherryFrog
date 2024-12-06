using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text cherryCount;

    void Update()
    {
        healthText.text = $"Health: {player.CurrHealth} / {player.MaxHealth}";
        cherryCount.text = $"Cherry: {player.CherryCount}";
    }
}
