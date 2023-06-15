using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ButtonActions", menuName = "scriptableObjects/ButtonActions")]
public class buttonFunctionsSO : ScriptableObject
{
    enum CurrentAction
    {
        startGame,
        Controls,
        quitGame,
        resetLevel,
        resume,
        mainMenu,
        volumeSlider,
        easterEgg,
        goBack,
    }

    [SerializeField] CurrentAction currentAction;

    public void RunButton()
    {
        if(currentAction == CurrentAction.startGame)
        {
            StartGame();
        }

        if (currentAction == CurrentAction.Controls)
        {
            Controls();
        }

        if (currentAction == CurrentAction.quitGame)
        {
            QuitGame();
        }

        if (currentAction == CurrentAction.resetLevel)
        {
            ResetLevel();
        }

        if (currentAction == CurrentAction.resume)
        {
            Resume();
        }

        if (currentAction == CurrentAction.mainMenu)
        {
            MainMenu();
        }

        if (currentAction == CurrentAction.volumeSlider)
        {
            VolumeSlider();
        }

        if (currentAction == CurrentAction.easterEgg)
        {
            EasterEgg();
        }

        if (currentAction == CurrentAction.goBack)
        {
            GoBack();
        }
    }


    void StartGame()
    {
        UIButtons.Instance.PLAY();
        Debug.Log("StartGame pressed");
    }

    void Controls()
    {
        UIButtons.Instance.KEYMAP();
        Debug.Log("Controls pressed");
    }

    void QuitGame()
    {
        UIButtons.Instance.EXIT();
        Debug.Log("QuitGame pressed");
    }

    void ResetLevel()
    {
        UIButtons.Instance.RESETLEVEL();
        Debug.Log("Reset Level pressed");
    }

    void Resume()
    {
        UIButtons.Instance.PLAY();
        Debug.Log("Resume pressed");
    }

    void MainMenu()
    {
        UIButtons.Instance.MAINMENU();
        Debug.Log("Main Menu pressed");
    }

    void VolumeSlider()
    {
        UIButtons.Instance.VOLUME();
        Debug.Log("Volume Slider pressed");
    }

    void EasterEgg()
    {
        UIButtons.Instance.EASTEREGG();
        Debug.Log("Easter Egg pressed");
    }

    void GoBack()
    {
        UIButtons.Instance.CLOSE();
        Debug.Log("GoBack pressed");
    }


}
