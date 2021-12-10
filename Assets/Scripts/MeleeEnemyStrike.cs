using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyStrike : MonoBehaviour
{

    public int damage = 10;


    private void OnTriggerEnter(Collider other)
    {
        PlayerCombat player = other.GetComponent<PlayerCombat>();
        if (player != null)
        {
            player.PlayerDamaged(damage);
        }
    }

}
