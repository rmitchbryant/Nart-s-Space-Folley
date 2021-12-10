using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles displaying the Player's current buffs on the screen

public class BuffText : MonoBehaviour
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
