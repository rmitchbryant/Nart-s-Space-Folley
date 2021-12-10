using UnityEngine.Audio;
using UnityEngine;

// Custom class to define the Sound class

[System.Serializable] // Use Serializable to make custom classes appear in the inspector
public class Sound
{

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
