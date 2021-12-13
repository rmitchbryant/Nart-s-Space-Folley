using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles dislpaying the red recharging text

public class RailGunText : MonoBehaviour
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
