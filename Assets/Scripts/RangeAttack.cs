using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    Animator animator;
    public ReloadText reloadText;
    public AmmoClip ammoClip;

    public float bulletForce = 20f;
    public bool reloading = false;
    public float reloadTime = 10f;

    public int ammo = 20;
    public int fullClip = 20;
    public bool infiniteAmmo = false;

    // Start is called before the first frame update
    void Start()
    {
        ammoClip.Ammo(ammo.ToString());
        animator = GetComponentInChildren<Animator>();
    }

    public void Shoot()
    {
        if (ammo > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

            if (ammo < 6)
            {
                FindObjectOfType<AudioManager>().Play("Shoot");
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Shoot Low");
            }

            if (!infiniteAmmo)
            {
                ammo -= 1;
                ammoClip.Ammo(ammo.ToString());
            }
        }
        //else if (ammo == 0)
        //{
        //    ammo -= 1;
        //    StartCoroutine(Reload());

        //}
    }

    public void Reload()
    {
        if (ammo == fullClip)
        {
            Debug.Log("Full clip");
            return;
        }
        else
        {
            StartCoroutine(Reloading());
        }
    }

    public int GetAmmo()
    {
        return ammo;
    }

    public float GetReloadTime()
    {
        return reloadTime;
    }

    public bool IsReloading()
    {
        return reloading;
    }

    public int GetFullClip()
    {
        return fullClip;
    }

    public void isInfiniteAmmo(bool infiniteAmmo)
    {
        this.infiniteAmmo = infiniteAmmo;
    }

    public void setAmmoFull()
    {
        ammo = fullClip;
        ammoClip.Ammo(fullClip.ToString());
    }

    IEnumerator Reloading()
    {
        animator.Play("Reload");
        FindObjectOfType<AudioManager>().Play("Reload");
        reloadText.Show();
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        ammo = fullClip;
        ammoClip.Ammo(ammo.ToString());
        reloadText.Disappear();
        reloading = false;
    }
}
