using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RailGun : MonoBehaviour
{

    public int damage = 50;
    public float range = 100f;
    public Transform firePoint;
    //public GameObject impactEffect;
    public LineRenderer line;
    public float startWidth = 0.5f;
    public float endWidth = 0.5f;

    private void Start()
    {
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
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
            Debug.Log(hit.transform.name);

            //Instantiate(impactEffect, hit.point, Quaternion.identity);

            line.startWidth = startWidth;
            line.endWidth = endWidth;

            line.SetPosition(0, firePoint.position);
            //line.SetPosition(1, firePoint.position + firePoint.forward * 100);
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.startWidth = startWidth;
            line.endWidth = endWidth;

            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, firePoint.position + firePoint.forward * 100);
        }

        StartCoroutine(lineWait());

    }

    IEnumerator lineWait()
    {
        line.enabled = true;

        yield return new WaitForSeconds(0.1f);

        line.enabled = false;
    }
}
