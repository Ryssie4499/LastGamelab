using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ButtonActions", menuName = "scriptableObjects/ButtonActions")]
public class buttonFunctionsSO : ScriptableObject
{
    enum CurrentAcrion
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

    [SerializeField] CurrentAcrion currentAction;

    public void RunButton()
    {
        if(currentAction == CurrentAcrion.startGame)
        {
            StartGame();
        }

        if (currentAction == CurrentAcrion.Controls)
        {
            Controls();
        }

        if (currentAction == CurrentAcrion.quitGame)
        {
            QuitGame();
        }

        if (currentAction == CurrentAcrion.resetLevel)
        {
            ResetLevel();
        }

        if (currentAction == CurrentAcrion.resume)
        {
            Resume();
        }

        if (currentAction == CurrentAcrion.mainMenu)
        {
            MainMenu();
        }

        if (currentAction == CurrentAcrion.volumeSlider)
        {
            VolumeSlider();
        }

        if (currentAction == CurrentAcrion.easterEgg)
        {
            EasterEgg();
        }

        if (currentAction == CurrentAcrion.goBack)
        {
            GoBack();
        }
    }


    void StartGame()
    {
        Debug.Log("StartGame pressed");
    }

    void Controls()
    {
        Debug.Log("Controls pressed");
    }

    void QuitGame()
    {
        Debug.Log("QuitGame pressed");
    }

    void ResetLevel()
    {
        Debug.Log("Reset Level pressed");
    }

    void Resume()
    {
        Debug.Log("Resume pressed");
    }

    void MainMenu()
    {
        Debug.Log("Main Menu pressed");
    }

    void VolumeSlider()
    {
        Debug.Log("Volume Slider pressed");
    }

    void EasterEgg()
    {
        Debug.Log("Easter Egg pressed");
    }

    void GoBack()
    {
        Debug.Log("GoBack pressed");
    }


}
