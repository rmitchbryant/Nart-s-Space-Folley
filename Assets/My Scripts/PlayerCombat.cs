using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script controls the player characters health and death

public class PlayerCombat : MonoBehaviour
{
    // HealthBar is a separate script that was created for the game on the 
    // HealthBar object under HUD
    public HealthBar healthBar;

    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;

    public bool playerDead = false;
    public bool invulnerable = false;

    GameObject enemy;
    public GameOverScreen gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Start with the players health at full
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Make sure health does not exceed the maximum
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }


        // Intentionally damage the player for debugging purposes
        if (Input.GetKeyDown("k"))
        {
            Debug.Log("Ouch!");
            PlayerDamaged(25);
        }

        // Deal heavy damage to the enemy for debugging purposes
        if (Input.GetKeyDown("j"))
        {

            if (invulnerable)
            {
                Debug.Log("Invulnerability off.");
                invulnerable = false;
            }
            else
            {
                Debug.Log("Invulnerability on.");
                invulnerable = true;
            }

        }

        // Allow the restart of the level
        if (playerDead)
        {
            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

    }

    // Count damage to the player
    public void PlayerDamaged(int damage)
    {
        // Determine if the player is invulnerable
        if (!invulnerable)
        {

            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (!playerDead)
            {
                //FindObjectOfType<AudioManager>().Play("Hit");
            }

            // Let the player die if health drops to 0
            if (currentHealth <= 0)
            {
                PlayerDie();
            }
        }
    }

    // The player dies
    void PlayerDie()
    {
        Debug.Log("Player has died!");

        playerDead = true;

        FindObjectOfType<AudioManager>().Play("Player Death");

        animator.Play("Die");

        // Prevent the player from moving after dead
        GetComponent<CharacterController>().enabled = false;
        GetComponent<ThirdPersonMovement>().enabled = false;
        GetComponentInChildren<PlayerLookDirection>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

        // Display the game over screen
        gameOver.SetUp();


    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void IsInvulnerable(bool invulnerable)
    {
        this.invulnerable = invulnerable;
    }

    public bool IsDead()
    {
        return playerDead;
    }
}
