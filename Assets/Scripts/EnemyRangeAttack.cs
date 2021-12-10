using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{

    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public void Shoot(int alternateBarrels)
    {
        if (alternateBarrels > 0)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            FindObjectOfType<AudioManager>().Play("Enemy Shoot");
        }
        else
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint2.forward * bulletForce, ForceMode.Impulse);
            FindObjectOfType<AudioManager>().Play("Enemy Shoot");

        }
    }
}
