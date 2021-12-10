using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the Melee Enemy attack

public class MeleeEnemyStrike : MonoBehaviour
{

    public int damage = 10;

    // If the player comes into contact with the enemy's claw, deal damage
    private void OnTriggerEnter(Collider other)
    {
        PlayerCombat player = other.GetComponent<PlayerCombat>();
        if (player != null)
        {
            player.PlayerDamaged(damage);
        }
    }

}
