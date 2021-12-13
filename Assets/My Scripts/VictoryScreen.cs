using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script displays the victory screen when the game is won

public class VictoryScreen : MonoBehaviour
{
    public void SetUp()
    {
        gameObject.SetActive(true);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
