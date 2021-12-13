using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script displays the number percentage of the railgun's recharge

public class RailGunRecharge : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        text.text = "100%";
    }

    public void SetPercentage(string percentage)
    {
        text.text = percentage + "%";
    }



}
