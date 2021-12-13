using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for the first ship part to be picked up

public class ShipItemsPart1 : MonoBehaviour
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
