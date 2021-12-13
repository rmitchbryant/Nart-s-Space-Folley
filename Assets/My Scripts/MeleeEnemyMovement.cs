using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This script is used for the movement of mobile enemies

public class MeleeEnemyMovement : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    Vector3 startingPosition;
    public Animator animator;

    public float lookRadius = 10f;
    public float enemyAttackRange = 2f;
    public float lookAroundTime = 2f;

    public bool looking = false;


    // Start is called before the first frame update
    void Start()
    {
        // Set up the enemy object and set their starting position for return
        player = GameObject.FindGameObjectWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        startingPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Be sure to check the player exists in the scene
        if (player == null)
        {
            return;
        }

        if (this.GetComponent<EnemyController>() != null)
        {
            // Make sure the enemy isn't dead
            if (!this.GetComponent<EnemyController>().IsDead())
            {

                float startDistance = Vector3.Distance(startingPosition, transform.position);

                if (player != null)
                {
                    // Determine the distance from the enemy to the player
                    float playerDistance = Vector3.Distance(player.transform.position, transform.position);
                    
                    if (playerDistance <= lookRadius)
                    {
                        // Stop any previously running coroutines
                        StopAllCoroutines();
                        looking = true;
                        animator.SetBool("isLooking", false);

                        // Make the enemy move to the players position
                        agent.SetDestination(player.transform.position);
                        animator.SetBool("meleeWalking", true);

                        // Determine if the player is close enough to attack
                        if (playerDistance <= agent.stoppingDistance)
                        {
                            // Make sure the enemy stops walking and is facing the player
                            animator.SetBool("meleeWalking", false);
                            FaceTarget();
                            agent.SetDestination(transform.position);
                            animator.Play("Armature|Attack_4");
                            FindObjectOfType<AudioManager>().Play("Alien Grunt");

                        }
                    }
                    else
                    {

                        if (startDistance <= agent.stoppingDistance)
                        {
                            // If the enemy is back at it's initial position stop walking
                            animator.SetBool("meleeWalking", false);
                        }

                        if (looking)
                        {
                            // Have the enemy look for the player and wait to return
                            agent.SetDestination(transform.position);
                            StartCoroutine(MoveBack());

                        }

                    }
                }
            }
            else
            {
                agent.isStopped = true;
                animator.SetBool("meleeWalking", false);
            }
        }
        else
        {
            //Debug.Log("Cannot find the enemy controller.");
        }


    }

    // Be sure to have the enemy face the player even when not moving
    void FaceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Have the enemy wait a set time and then move back to the starting position
    IEnumerator MoveBack()
    {
        animator.SetBool("isLooking", true);
        looking = false;
        yield return new WaitForSeconds(lookAroundTime);

        // Have the enemy move back to it's starting position
        agent.SetDestination(startingPosition);
        animator.SetBool("isLooking", false);
        animator.SetBool("meleeWalking", true);
    }

    // Display the enemy's detection radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookRadius);


    }
}
