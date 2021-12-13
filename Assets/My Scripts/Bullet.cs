using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script contains logic for the players bullet

public class Bullet : MonoBehaviour
{

    public int damage = 5;

    void OnTriggerEnter(Collider other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            // Cause damage to the enemy
            enemy.TakeDamage(damage);
        }
        EnemyTurretController turret = other.GetComponent<EnemyTurretController>();
        if (turret != null)
        {
            // In case the enemy is a turret
            turret.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        // Destroy the bullet if it happens to go to far
        if (transform.position.x > 200 || transform.position.x < -200 || transform.position.z > 200 || transform.position.z < -200)
        {
            Destroy(gameObject);
        }
    }
}
