using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAudio : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    private float loopStart = 1.0f;
    private float loopEnd = 8.0f;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.time = loopStart;
        audioSource.loop = true;
        audioSource.volume = 0.2f;
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.time = loopStart;
            audioSource.Play();
        }

        if (audioSource.time >= loopEnd)
        {
            audioSource.time = loopStart;
        }

        if(PauseMenuManager.gamePaused)
        {
            audioSource.Pause();
        }
    }
}