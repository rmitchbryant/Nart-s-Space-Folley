using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for the second ship part to be picked up

public class ShipItemsPart2 : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }
}
