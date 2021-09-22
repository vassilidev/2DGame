using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            playNextSong();
        }
    }

    private void playNextSong()
    {
        
    }
}