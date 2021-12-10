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

    //public Transform enemyAttackPoint;
    //public LayerMask playerLayer;

    public float lookRadius = 10f;
    public float enemyAttackRange = 2f;
    public float lookAroundTime = 2f;

    public bool looking = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        startingPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Debug.Log("There's no player!");
            return;
        }

        if (this.GetComponent<EnemyController>() != null)
        {

            if (!this.GetComponent<EnemyController>().IsDead())
            {

                float startDistance = Vector3.Distance(startingPosition, transform.position);
                //Debug.Log("start " + startDistance);

                if (player != null)
                {
                    float playerDistance = Vector3.Distance(player.transform.position, transform.position);
                    //Debug.Log("player " + playerDistance);

                    if (playerDistance <= lookRadius)
                    {
                        StopAllCoroutines();
                        looking = true;
                        animator.SetBool("isLooking", false);

                        agent.SetDestination(player.transform.position);
                        animator.SetBool("meleeWalking", true);

                        if (playerDistance <= agent.stoppingDistance)
                        {
                            Debug.Log("At player");
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
                            animator.SetBool("meleeWalking", false);
                            Debug.Log("Back at start");
                        }

                        if (looking)
                        {
                            agent.SetDestination(transform.position);
                            Debug.Log("Start coroutine");
                            StartCoroutine(MoveBack());

                        }

                    }
                }
            }
            else
            {
                agent.isStopped = true;
                animator.SetBool("meleeWalking", false);
                Debug.Log("Second stopping");
            }
        }
        else
        {
            Debug.Log("Cannot find the enemy controller.");
        }


    }

    void FaceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    IEnumerator MoveBack()
    {
        animator.SetBool("isLooking", true);
        Debug.Log("Where'd he go?");
        looking = false;
        yield return new WaitForSeconds(lookAroundTime);

        Debug.Log("Going back");
        agent.SetDestination(startingPosition);
        animator.SetBool("isLooking", false);
        animator.SetBool("meleeWalking", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookRadius);


    }
}
