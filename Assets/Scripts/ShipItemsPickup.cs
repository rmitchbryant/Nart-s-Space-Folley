using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script controls when the player picks up a ship part

public class ShipItemsPickup : MonoBehaviour
{
    public ToNextLevel next;
    public ShipItemsDisplay parts;

    private void OnTriggerEnter(Collider other)
    {
        PlayerCombat player = other.GetComponent<PlayerCombat>();
        if (player != null)
        {
            // Play a sound
            FindObjectOfType<AudioManager>().Play("Part Pickup");

            // Increase count to open the next level
            next.IncreaseCount();

            // Increase count to display parts picked up
            parts.IncreaseCount();

            // Destroy the object
            Destroy(gameObject);
        }
    }

}
