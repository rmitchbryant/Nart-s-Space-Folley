using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the logic for the Health Pickups

public class HealthRestore : MonoBehaviour
{

    public int healthRestore = 25;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player comes into contact
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    private void Pickup(Collider player)
    {
        // Play a sound
        FindObjectOfType<AudioManager>().Play("Health Pickup");

        // Restore health to the player
        PlayerCombat health = player.GetComponent<PlayerCombat>();
        PlayerCombat bar = player.GetComponent<PlayerCombat>();
        bar.healthBar.SetHealth(health.currentHealth += healthRestore);


        Destroy(gameObject);

    }
}
