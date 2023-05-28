using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    public GameObject MainMenuUI, SettingsUI, PauseUI;
    public ScoreBehaviour scoreBehaviour;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
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
    }
    public void onPauseGame()
    {
        Time.timeScale = 0.0f;
        PauseUI.SetActive(true);
        SettingsUI.SetActive(false);
    }
    
}
