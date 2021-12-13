using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles shooting for the burst fire turrets

public class BurstRangeAttack : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public int burstSize = 3;
    public float rateOfFire = 500f;

    float bulletDelay = 0f;

    public void Shoot()
    {
        StartCoroutine(Burst());
    }

    // Shoot a set amount of bullets in a burst
    IEnumerator Burst()
    {
        bulletDelay = 60 / rateOfFire;

        // Shoot the set amount of bullets
        for (int i = 0; i < burstSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            FindObjectOfType<AudioManager>().Play("Enemy Shoot");
            // Wait a set time before shooting the next bullet
            yield return new WaitForSeconds(bulletDelay);

        }

    }
}
