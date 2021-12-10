using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script handles displaying the players ammo

public class AmmoClip : MonoBehaviour
{
    public Text text;

    public void SetFullClip(string clip)
    {
        text.text = clip;
    }
    
    // Update the HUD with the current ammo
    public void Ammo(string ammo)
    {
        int ammoAmount = int.Parse(ammo);

        if (ammoAmount < 6)
        {
            // Set the color to red when running low on ammo
            text.color = Color.red;
        }
        else
        {
            text.color = Color.white;
        }

        text.text = ammo;
    }
}
