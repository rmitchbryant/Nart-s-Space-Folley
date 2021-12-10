using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the Parts element on the HUD

public class ShipItemsDisplay : MonoBehaviour
{
    public int count = 0;
    public ShipItemsPart1 part1;
    public ShipItemsPart2 part2;

    // Determine whether to show one or two parts
    public void IncreaseCount()
    {
        count++;

        if (count > 0)
        {
            part1.Show();
        }
        
        if (count > 1)
        {
            part2.Show();
        }
    }

}
