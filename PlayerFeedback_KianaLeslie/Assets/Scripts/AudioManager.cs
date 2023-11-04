using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgMusic;
    public AudioSource computerAudio;
    public AudioSource doorAudio;
    public AudioSource sparksAudio;

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
        computerAudio.Pause();
        doorAudio.Pause();
        sparksAudio.Pause();
    }

    private void ResumeAudio()
    {
        bgMusic.UnPause();
        computerAudio.UnPause();
        doorAudio.UnPause();
        sparksAudio.UnPause();
    }
}