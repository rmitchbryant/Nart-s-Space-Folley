using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for displaying the Infinite Ammo active buff on the HUD

public class InfiniteAmmoEffect : MonoBehaviour
{

    public GameObject infiniteAmmoEffect;

    public void Show()
    {
        infiniteAmmoEffect.SetActive(true);
    }

    public void Disappear()
    {
        infiniteAmmoEffect.SetActive(false);
    }

}
