using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    public GameObject MainMenuUI, SettingsUI, PauseUI;
    public ScoreBehaviour scoreBehaviour;
    public Sprite soundSprite, muteSprite;
    public BackgroundMusicBehaviour bgMusic;
    public Image soundIcon;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel") && scoreBehaviour.getGamePlaying())
        {
            onPauseGame();
        }
    }

    public void onStart()
    {
        Time.timeScale = 1.0f;
        scoreBehaviour.startGame();
        MainMenuUI.SetActive(false);
    }

    public void onReplayGame()
    {
        Time.timeScale = 1.0f;
    }
    public void onExitGme()
    {
        Application.Quit();
    }
    public void onResumeGame()
    {
        Time.timeScale = 1.0f;
        PauseUI.SetActive(false);
    }
    public void settingsMenu()
    {
        SettingsUI.SetActive(true);
        PauseUI.SetActive(false);
        MainMenuUI.SetActive(false);
    }
    public void onPauseGame()
    {
        Time.timeScale = 0.0f;
        PauseUI.SetActive(true);
        SettingsUI.SetActive(false);
    }

    public void onClickSettingsBack()
    {
        if(scoreBehaviour.getGamePlaying())
        {
            //if gmae is playing, then we go back to pause menu
            onPauseGame();
        }
        else
        {
            //otherwise back to main menu
            SettingsUI.SetActive(false);
            PauseUI.SetActive(false);
            MainMenuUI.SetActive(true);
        }
    }

    //Audio and Speaker icon
    public void onSoundButton()
    {
        if(bgMusic.bgMuteStatus())
        {
            //if mute, change is sound
            soundIcon.sprite = soundSprite;
            bgMusic.bgSound();
        }
        else
        {
            //if not muted, soundis playing. Change to mute
            soundIcon.sprite = muteSprite;
            bgMusic.bgMute();
        }
    }
    
}
