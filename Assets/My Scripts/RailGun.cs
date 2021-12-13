using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script handles the RailGun behavior

public class RailGun : MonoBehaviour
{

    public int damage = 50;
    public float range = 100f;
    public Transform firePoint;
    public LineRenderer line;
    public float startWidth = 0.5f;
    public float endWidth = 0.5f;

    private void Start()
    {
    }

    public void Shoot()
    {
        // Determine if the railgun hits anything
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            // If it hits an enemy, deal damage
            EnemyController enemy = hit.transform.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            EnemyTurretController turret = hit.transform.GetComponent<EnemyTurretController>();
            if (turret != null)
            {
                turret.TakeDamage(damage);
            }

            // Determine the size of the railgun effect
            line.startWidth = startWidth;
            line.endWidth = endWidth;

            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, hit.point);
        }
        else
        {
            // Determine the size of the railgun does not hit anything
            line.startWidth = startWidth;
            line.endWidth = endWidth;

            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, firePoint.position + firePoint.forward * 100);
        }

        StartCoroutine(lineWait());

    }

    // Determine how long the line appears
    IEnumerator lineWait()
    {
        line.enabled = true;

        yield return new WaitForSeconds(0.1f);

        line.enabled = false;
    }
}
