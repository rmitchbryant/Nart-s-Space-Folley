using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the player movement utilizing Unity's input manager
// It allows the character to move in relation to the camera

public class ThirdPersonMovement : MonoBehaviour
{

    CharacterController controller;
    public Transform cam;
    public float speed = 0f;
    public float runSpeed = 12.0f;
    public float shootSpeed = 6.0f;
    public bool isWalkShooting = false;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float nextDashTime = 0f;
    public float dashSpeed = 10f;
    public float dashCooldown = 5f;
    RangeAttack reloading;

    public float mouseAngle;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        reloading = this.GetComponent<RangeAttack>();
        controller = this.GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        // Get movement input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // If input is found move the player in relation to the camera view
        if (direction.magnitude >= 0.1f && !reloading.IsReloading())
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Determine if the player is shooting to slow down speed reloading works at normal speed
            if (Input.GetMouseButton(0) && reloading != null && reloading.GetAmmo() > 0)
            {
                isWalkShooting = true;
                speed = shootSpeed;
            }
            else
            {
                isWalkShooting = false;
                speed = runSpeed;
            }

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            animator.SetBool("isRunning", true);

            // Determine the way the player walks when shooting
            if (isWalkShooting)
            {
                if (moveDir.z > 0 && moveDir.x < 0)
                {
                    WalkShootForward();
                }
                else if (moveDir.z < 0 && moveDir.x > 0)
                {
                    WalkShootBackward();
                }
                else if (moveDir.z > 0 && moveDir.x > 0)
                {
                    WalkShootRight();
                }
                else
                {
                    WalkShootLeft();
                }
            }
            else
            {
                NotWalkShooting();
            }

            // This was used to apply a dash effect
            //if (Time.time >= nextDashTime)
            //{
            //    if (Input.GetButtonDown("Jump"))
            //    {
            //        controller.Move(moveDir.normalized * speed * dashSpeed * Time.deltaTime);
            //        nextDashTime = Time.time + (dashCooldown);
            //    }
            //}

        }
        else
        {
            isWalkShooting = false;
            animator.SetBool("isRunning", false);
            NotWalkShooting();
        }



    }

    // Determine the leg movement as the player shoots and walks up
    public void WalkShootForward()
    {
        mouseAngle = GetComponent<PlayerLookDirection>().GetMouseAngle();

        if (mouseAngle < 45 && mouseAngle > -45)
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingForward", true);
        }
        else if (mouseAngle < -45 && mouseAngle > -135)
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingLeft", true);
        }
        else if (mouseAngle < -135 && mouseAngle > -225)
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingBackward", true);
        }
        else
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingRight", true);
        }

    }

    // Determine the leg movement as the player shoots while moving down
    private void WalkShootBackward()
    {
        mouseAngle = GetComponent<PlayerLookDirection>().GetMouseAngle();

        if (mouseAngle < 45 && mouseAngle > -45)
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingBackward", true);
        }
        else if (mouseAngle < -45 && mouseAngle > -135)
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingRight", true);
        }
        else if (mouseAngle < -135 && mouseAngle > -225)
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingForward", true);
        }
        else
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingLeft", true);
        }
    }

    // Determine the leg movement as the player shoots while moving right
    private void WalkShootRight()
    {
        mouseAngle = GetComponent<PlayerLookDirection>().GetMouseAngle();

        if (mouseAngle < 45 && mouseAngle > -45)
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingRight", true);
        }
        else if (mouseAngle < -45 && mouseAngle > -135)
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingForward", true);
        }
        else if (mouseAngle < -135 && mouseAngle > -225)
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingLeft", true);
        }
        else
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingBackward", true);
        }

    }

    // Determine the leg movement as the player shoots while moving left
    private void WalkShootLeft()
    {
        mouseAngle = GetComponent<PlayerLookDirection>().GetMouseAngle();

        if (mouseAngle < 45 && mouseAngle > -45)
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingLeft", true);
        }
        else if (mouseAngle < -45 && mouseAngle > -135)
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingBackward", true);
        }
        else if (mouseAngle < -135 && mouseAngle > -225)
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingRight", true);
        }
        else
        {
            NotWalkShooting();
            animator.SetBool("isWalkShootingForward", true);
        }

    }

    // Stop all walk and shooting animations
    public void NotWalkShooting()
    {
        animator.SetBool("isWalkShootingForward", false);
        animator.SetBool("isWalkShootingLeft", false);
        animator.SetBool("isWalkShootingRight", false);
        animator.SetBool("isWalkShootingBackward", false);
    }

    public CharacterController GetCharacterController()
    {
        return controller;
    }
}
