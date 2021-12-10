using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
