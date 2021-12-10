using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will control the direction the player is facing by having it follow the mouse
// It also handles shooting as that is greatly dependent on direction the character is facing

public class PlayerLookDirection : MonoBehaviour
{
    public RangeAttack reloading;
    public PlayerCombat player;

    public float nextShootTime = 0f;
    public float rateOfFire = 10f;
    public bool railgunRecharge = true;
    public float railgunRate = 5f;
    public RailGunText railGunText;
    public RailGunRecharge railGunRecharge;

    Vector3 mousePos = Vector3.zero;
    float angle = 0f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading == null)
        {
            Debug.Log("The Range Attack Component wasn't found.");
            return;
        }

        // Look in the direction you're shooting and shoot
        if (Input.GetMouseButton(0) && !reloading.IsReloading() && reloading.GetAmmo() > 0)
        {
            Look();
            animator.SetBool("isShooting", true);

            if (Time.time >= nextShootTime && !player.IsDead())
            {
                RangeAttack range = gameObject.GetComponent<RangeAttack>();
                range.Shoot();
                nextShootTime = Time.time + (1f / rateOfFire);
            }

        }
        else
        {

            animator.SetBool("isShooting", false);
        }

        // Shoot the railgun
        if (railgunRecharge)
        {
            railGunText.Disappear();

            if (Input.GetMouseButtonDown(1) && !player.IsDead())
            {
                Look();
                railgunRecharge = false;
                animator.Play("Shoot_SingleShot_AR");
                gameObject.GetComponent<RailGun>().Shoot();
                StartCoroutine(railGunPercentage(railgunRate));
                railGunText.Show();
            }
        }

        if (Input.GetKeyDown("r"))
        {
            reloading.Reload();
        }
    }

    // Determines the recharge of the RailGun and displays it
    IEnumerator railGunPercentage(float rechargeRate)
    {
        float percentage = 0f;
        railGunRecharge.SetPercentage(percentage.ToString());
        for (int i = 0; i < 100; i++)
        {
            percentage += 1;
            railGunRecharge.SetPercentage(percentage.ToString());
            yield return new WaitForSeconds((rechargeRate) / (100));
        }

        railgunRecharge = true;
    }

    // Determines the direction the character is facing
    private void Look()
    {
        mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));

        //Debug.Log("Mouse angle = " + angle);
    }

    public Vector3 GetMousePos()
    {
        return mousePos;
    }

    public float GetMouseAngle()
    {
        return angle;
    }

}
