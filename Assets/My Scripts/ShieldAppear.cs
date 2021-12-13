using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script enables the invulnerable shield when the power up is picked up

public class ShieldAppear : MonoBehaviour
{

    public MeshRenderer shieldGFX;
    public SphereCollider shield;

    public void Show()
    {
        shieldGFX.enabled = true;
        shield.enabled = true;
    }

    public void Disappear()
    {
        shieldGFX.enabled = false;
        shield.enabled = false;
    }
}
