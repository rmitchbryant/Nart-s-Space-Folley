using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the Invulnerable power up

public class PowerUpInvulnerable : MonoBehaviour
{
    public float duration;

    public BuffUI buffUI;
    public BuffText invulnerability;

    private void OnTriggerEnter(Collider other)
    {
        // Determine if the player comes into contact with the pickup
        if (other.CompareTag("Player"))
        {
            PlayerCombat player = other.GetComponent<PlayerCombat>();
            ShieldAppear shield = other.GetComponentInChildren<ShieldAppear>();
            StartCoroutine(Invulnerable(player, shield));
        }
    }

    IEnumerator Invulnerable(PlayerCombat player, ShieldAppear shield)
    {
        // Play a sound and display the visual aspects of the power up
        FindObjectOfType<AudioManager>().Play("Invulnerable");
        buffUI.IncreaseCount();
        invulnerability.Show();
        shield.Show();

        // Make the player invulnerable
        player.IsInvulnerable(true);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

        yield return new WaitForSeconds(duration);

        // Make the player vulnerable again
        player.IsInvulnerable(false);

        // Adjust the HUD elements
        buffUI.DecreaseCount();
        invulnerability.Disappear();
        shield.Disappear();

        Destroy(gameObject);

    }
}
