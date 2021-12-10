using UnityEngine.Audio;
using System;
using UnityEngine;

// Script to manage the audio for the game

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        // Have the audio manager persist through the game, but only one instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Keep the object when a new scene is loaded

        // Store the sounds in an array
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        //Play("Music");
    }

    public void Play (string name)
    {
        // Find the sound you want to play and play it 
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound " + name + " was not found.");
            return;
        }
        s.source.Play();
    }
}
