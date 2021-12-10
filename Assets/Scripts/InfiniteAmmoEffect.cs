using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
