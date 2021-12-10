using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffUI : MonoBehaviour
{

    public int count = 0;

    public void IncreaseCount()
    {
        count++;
        gameObject.SetActive(true);
    }

    public void DecreaseCount()
    {
        count--;
        if (count < 1)
        {
            gameObject.SetActive(false);
        }
    }
}
