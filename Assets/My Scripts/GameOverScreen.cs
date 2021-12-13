using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script will control the Game Over Screen should the palyer lose
// It will allow the player to retry the level or return to the main menu

public class GameOverScreen : MonoBehaviour
{
    public void SetUp()
    {
        gameObject.SetActive(true);
    }

    // Allow the player to restart the level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Allow the player to go back to the Main Menu
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
