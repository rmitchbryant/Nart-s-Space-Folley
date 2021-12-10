using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
