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
    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlaySlashSoundFX()
    {
        
    }

    public void PlaySlicedSoundFX()
    {
        
    }

    public void PlayBackgroundMusic(float volume = 1f)
    {
        audioSource.PlayOneShot(backgroundMusic, volume);
    }

    public void StopBackgroundMusic(float volume = 0f)
    {
        audioSource.PlayOneShot(backgroundMusic, volume);
    }


}
