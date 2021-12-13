using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the enemy bullets to damage the player

public class EnemyBullet : MonoBehaviour
{
    public int damage = 5;

    void OnTriggerEnter(Collider other)
    {
        PlayerCombat player = other.GetComponent<PlayerCombat>();
        if (player != null)
        {
            // Deal damage to the player
            player.PlayerDamaged(damage);
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        // Destroy the bullet if it gets too far
        if (transform.position.x > 200 || transform.position.x < -200 || transform.position.z > 200 || transform.position.z < -200)
        {
            Destroy(gameObject);
        }
    }
}
