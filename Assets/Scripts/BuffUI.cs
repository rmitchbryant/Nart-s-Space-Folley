using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the Active Buffs HUD element

public class BuffUI : MonoBehaviour
{

    public int count = 0;

    // Display the Active Buffs element if at least one buff is active
    public void IncreaseCount()
    {
        count++;
        gameObject.SetActive(true);
    }

    // Turn off the Active Buffs element if no buffs are active
    public void DecreaseCount()
    {
        count--;
        if (count < 1)
        {
            gameObject.SetActive(false);
        }
    }
}
