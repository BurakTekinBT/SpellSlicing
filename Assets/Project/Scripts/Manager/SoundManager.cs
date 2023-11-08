using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Fnote
    public AudioSource audioSource;
    public AudioClip backgroundMusic;
    public AudioClip slashSound;
    public AudioClip slicedSound;
    public AudioClip failSliced;
    public AudioClip successSliced;

    private bool isMuted = false;


    public void PlaySlashSoundFX()
    {
        
    }

    public void PlaySlicedSoundFX()
    {
        
    }

    public void OnBackgroundButtonPressed()
    {
        if (!isMuted)
        {
            isMuted = true;
            AudioListener.pause = true;
        }
        else
        {
            isMuted = false;
            AudioListener.pause = false;
        }

    }

}
