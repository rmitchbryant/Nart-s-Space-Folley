using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This script controls the enemy's Health and damage taken as well as death
// 

public class EnemyController : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public float deathDelay = 2f;
    bool isDead = false;

    public HealthBar healthBar;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(currentHealth);

        animator = GetComponentInChildren<Animator>();

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }

    }

    IEnumerator Die()
    {

        Debug.Log("Enemy died.");

        FindObjectOfType<AudioManager>().Play("Alien Death");
        animator.Play("Armature|Die");

        isDead = true;

        yield return new WaitForSeconds(deathDelay);

        Destroy(gameObject);

    }

    public bool IsDead()
    {
        return isDead;
    }
}
