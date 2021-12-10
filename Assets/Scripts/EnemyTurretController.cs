using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretController : MonoBehaviour
{

    public int maxHealth = 20;
    int currentHealth;
    public float deathDelay = 2f;
    bool isDead = false;

    public HealthBar healthBar;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(currentHealth);

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

        Instantiate(explosion, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play("Explosion");

        isDead = true;

        yield return new WaitForSeconds(deathDelay);

        Destroy(gameObject);

    }

    public bool IsDead()
    {
        return isDead;
    }
}
