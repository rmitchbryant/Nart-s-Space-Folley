using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the Infinite Ammo Power Up

public class PowerUpInfiniteAmmo : MonoBehaviour
{

    public float duration;
    public int fullClip;

    public BuffUI buffUI;
    public BuffText infiniteAmmoText;

    // Determine that the player has come into contact with the pick up
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Record the total ammo in a full cip and call the Infinite Ammo method
            RangeAttack reload = other.GetComponent<RangeAttack>();
            InfiniteAmmoEffect effect = other.GetComponentInChildren<InfiniteAmmoEffect>();
            fullClip = reload.GetFullClip();
            StartCoroutine(InfiniteAmmo(other, reload, effect));
        }
    }

    IEnumerator InfiniteAmmo(Collider player, RangeAttack reload, InfiniteAmmoEffect effect)
    {
        // Play a sound and adjust the HUD
        FindObjectOfType<AudioManager>().Play("Infinite Ammo");
        buffUI.IncreaseCount();
        infiniteAmmoText.Show();
        effect.Show();

        // Set the clip to full and turn on infinite ammo
        reload.isInfiniteAmmo(true);
        reload.setAmmoFull();

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(duration);

        // Turn off infinite ammo and adjust the HUD
        reload.isInfiniteAmmo(false);
        buffUI.DecreaseCount();
        infiniteAmmoText.Disappear();
        effect.Disappear();

        Destroy(gameObject);
    }
}
