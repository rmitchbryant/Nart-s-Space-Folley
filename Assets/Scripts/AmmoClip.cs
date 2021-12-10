using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoClip : MonoBehaviour
{
    public Text text;

    public void SetFullClip(string clip)
    {
        text.text = clip;
    }

    public void Ammo(string ammo)
    {
        int ammoAmount = int.Parse(ammo);

        if (ammoAmount < 6)
        {
            text.color = Color.red;
        }
        else
        {
            text.color = Color.white;
        }

        text.text = ammo;
    }
}
