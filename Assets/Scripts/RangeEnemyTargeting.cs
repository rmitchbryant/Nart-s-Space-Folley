using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (player != null && !this.GetComponent<EnemyTurretController>().IsDead())
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance <= lookRadius)
            {
                FaceTarget();
                animator.SetBool("turretShooting", true);

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

    void FaceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    IEnumerator BurstShoot()
    {
        yield return new WaitForSeconds(shootDelay);

        burst.Shoot();
    }

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);


    }
}
