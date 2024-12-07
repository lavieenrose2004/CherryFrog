using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowBorder : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GoToStartingPos();
        }
    }
}
