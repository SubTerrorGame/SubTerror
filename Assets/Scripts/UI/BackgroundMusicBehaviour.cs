using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicBehaviour : MonoBehaviour
{
    private AudioSource audioSource; 

    public AudioClip menuTheme, gameplayTheme;

    // Start is called before the first frame update
    void Start()
    {
        audioSource =gameObject.GetComponent<AudioSource>();
        audioSource.Play(0);
    }

    //mutes audio
    public void bgMute() 
    {
        audioSource.mute = true;
    }

    //unmutes audio
    public void bgSound()
    {
        audioSource.mute = false;
    }

    //returns if audio is currently muted or no
    public bool bgMuteStatus()
    {
        return audioSource.mute;
    }
    
    public void  playMainMenuTheme()
    {
        audioSource.clip = menuTheme;
        audioSource.Play();
    }
    public void playGameplayTheme()
    {
        audioSource.clip = gameplayTheme;
        audioSource.Play();

    }
}
