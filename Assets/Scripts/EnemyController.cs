using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This script controls the enemy's Health and damage taken as well as death
// It also allows the enemy to drop a pickup

public class EnemyController : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public float deathDelay = 2f;
    bool isDead = false;

    public HealthBar healthBar;
    public Animator animator;

    public GameObject drop;
    private Vector3 dropPosition;
    private int dropChance;
    private bool dropItem = true;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(currentHealth);

        animator = GetComponentInChildren<Animator>();

    }

    // Allow the enemy to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Set the enemy's health bar accordingly
        healthBar.SetHealth(currentHealth);

        // Determine if the enemy dies
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());

            // Make sure the item has only one chance to drop
            if (dropItem)
            {
                dropItem = false;

                dropChance = Random.Range(0, 5);

                Debug.Log("Drop Chance: " + dropChance);

                if (dropChance == 2)
                {
                    if (drop != null)
                    {
                        dropPosition = new Vector3(transform.position.x, 1.0f, transform.position.z);
                        Instantiate(drop, dropPosition, transform.rotation);
                    }
                }

            }
        }

    }

    IEnumerator Die()
    {
        // Prevent the enemy from dealing damage as/after it dies
        GetComponentInChildren<SphereCollider>().enabled = false;

        // Play a death sound and animation
        FindObjectOfType<AudioManager>().Play("Alien Death");
        animator.Play("Armature|Die");

        isDead = true;

        // Wait some time so the animation can play out
        yield return new WaitForSeconds(deathDelay);

        Destroy(gameObject);

    }

    public bool IsDead()
    {
        return isDead;
    }
}
