using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvulnerable : MonoBehaviour
{
    public float duration;

    public BuffUI buffUI;
    public BuffText invulnerability;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCombat player = other.GetComponent<PlayerCombat>();
            ShieldAppear shield = other.GetComponentInChildren<ShieldAppear>();
            StartCoroutine(Invulnerable(player, shield));
        }
    }

    IEnumerator Invulnerable(PlayerCombat player, ShieldAppear shield)
    {
        FindObjectOfType<AudioManager>().Play("Invulnerable");
        buffUI.IncreaseCount();
        invulnerability.Show();
        shield.Show();

        player.IsInvulnerable(true);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

        yield return new WaitForSeconds(duration);

        player.IsInvulnerable(false);

        buffUI.DecreaseCount();
        invulnerability.Disappear();
        shield.Disappear();

        Destroy(gameObject);

    }
}
