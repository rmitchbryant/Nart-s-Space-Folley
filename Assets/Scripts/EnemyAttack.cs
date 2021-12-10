using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the Melee Enemy attacks
// This one is currently not in use

public class EnemyAttack : MonoBehaviour
{
    public float damageDelay;
    public Transform attackPoint;
    public LayerMask playerLayer;
    public float attackRange;
    public int attackDamage;


    public void Attack()
    {
        StartCoroutine(Hit());
    }

    // Play the animation, but with a delay so it looks like the attack does damage when it lands
    IEnumerator Hit()
    {
        Debug.Log("Attacking!");

        yield return new WaitForSeconds(damageDelay);

        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

        Debug.Log(hitPlayer.Length);

        foreach (Collider player in hitPlayer)
        {
            Debug.Log("Hit");
            if (player.GetComponent<PlayerCombat>() != null)
            {
                player.GetComponent<PlayerCombat>().PlayerDamaged(attackDamage);
            }
        }

    }

}
