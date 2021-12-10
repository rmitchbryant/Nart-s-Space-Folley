using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
