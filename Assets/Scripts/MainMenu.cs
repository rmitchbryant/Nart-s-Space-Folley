using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script controls the main menu allowing the player to start the game
// They player can also quit the game

public class MainMenu : MonoBehaviour
{
    // Let the player play the game
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    // Let the player quit the game
    public void QuitGame()
    {
        Debug.Log("Quitter...");
        Application.Quit();
    }

    // Play a sound when a button is pressed
    public void PlaySound(string name)
    {
        FindObjectOfType<AudioManager>().Play(name);

    }

}
