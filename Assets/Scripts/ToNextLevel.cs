using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script handles the transition spot the player uses to move to the next level

public class ToNextLevel : MonoBehaviour
{

    public int count = 0;

    // If the player comes into contact with the point load the next level
    private void OnTriggerEnter(Collider other)
    {
        PlayerCombat player = other.GetComponent<PlayerCombat>();
        if (player != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Activate the transition point once the player gets both parts
    public void IncreaseCount()
    {
        count++;

        if (count > 1)
        {
            gameObject.SetActive(true);
        }
    }

}
