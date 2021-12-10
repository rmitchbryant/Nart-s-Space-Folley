using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : MonoBehaviour
{

    public int healthRestore = 25;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    private void Pickup(Collider player)
    {
        FindObjectOfType<AudioManager>().Play("Health Pickup");

        PlayerCombat health = player.GetComponent<PlayerCombat>();
        PlayerCombat bar = player.GetComponent<PlayerCombat>();
        bar.healthBar.SetHealth(health.currentHealth += healthRestore);


        Destroy(gameObject);

    }
}
