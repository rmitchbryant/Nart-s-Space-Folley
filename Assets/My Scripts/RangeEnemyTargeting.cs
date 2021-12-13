using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the targeting for ranged enemies (turrets in this case)

public class RangeEnemyTargeting : MonoBehaviour
{
    GameObject player;
    public float lookRadius;
    BurstRangeAttack burst;
    EnemyRangeAttack shoot;
    public float nextShootTime = 0f;
    public float rateOfFire = 1f;
    public float shootDelay = 1f;
    public int alternateBarrels = 0;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        burst = this.GetComponent<BurstRangeAttack>();
        shoot = this.GetComponent<EnemyRangeAttack>();
                
    }

    // Update is called once per frame
    void Update()
    {
        // If the player exists and the turret is not dead
        if (player != null && !this.GetComponent<EnemyTurretController>().IsDead())
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            
            // Determine if the player is within the detection radius
            if (distance <= lookRadius)
            {
                FaceTarget();
                animator.SetBool("turretShooting", true);

                // Set how frequent the turret can shoot
                if (Time.time >= nextShootTime)
                {
                    if (burst != null)
                    {
                        nextShootTime = Time.time + (1f / rateOfFire);
                        StartCoroutine(BurstShoot());
                    }

                    if (shoot != null)
                    {
                        nextShootTime = Time.time + (1f / rateOfFire);
                        StartCoroutine(Shoot());
                    }

                }

            }
            else
            {
                animator.SetBool("turretShooting", false);
            }
        }

    }

    // Make sure to face the player
    void FaceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Call up the Burst Shoot method if the turret shoots in bursts
    IEnumerator BurstShoot()
    {
        yield return new WaitForSeconds(shootDelay);

        burst.Shoot();
    }

    // Call the regular shooting method if it doesn't shoot in bursts
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shootDelay);
        if (alternateBarrels > 0)
        {
            alternateBarrels--;
        }
        else
        {
            alternateBarrels++;
        }
        shoot.Shoot(alternateBarrels);
    }

    // Display the range of the detection radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);


    }
}
