using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgMusic;

    private bool isAudioPaused = false;

    private void Start()
    {
        isAudioPaused = false;
    }

    void Update()
    {
        if (PauseMenuManager.gamePaused)
        {
            if (!isAudioPaused)
            {
                PauseAudio();
                isAudioPaused = true;
            }
        }
        else
        {
            if (isAudioPaused)
            {
                ResumeAudio();
                isAudioPaused = false;
            }
        }
    }

    private void PauseAudio()
    {
        bgMusic.Pause();
    }

    private void ResumeAudio()
    {
        bgMusic.UnPause();
    }
}