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
        answer1,
        answer2,
        answer3
    }

    [SerializeField] CurrentAction currentAction;

    public void RunButton(UIButtons button, UICombat CombatButton)
    {
        if(currentAction == CurrentAction.startGame)
        {
            StartGame(button);
        }

        if (currentAction == CurrentAction.Controls)
        {
            Controls(button);
        }

        if (currentAction == CurrentAction.quitGame)
        {
            QuitGame(button);
        }

        if (currentAction == CurrentAction.resetLevel)
        {
            ResetLevel(button);
        }

        if (currentAction == CurrentAction.resume)
        {
            Resume(button);
        }

        if (currentAction == CurrentAction.mainMenu)
        {
            MainMenu(button);
        }

        if (currentAction == CurrentAction.volumeSlider)
        {
            VolumeSlider(button);
        }

        if (currentAction == CurrentAction.easterEgg)
        {
            EasterEgg(button);
        }

        if (currentAction == CurrentAction.goBack)
        {
            GoBack(button);
        }

        if(currentAction == CurrentAction.answer1)
        {
            Answer1(CombatButton);
        }

        if(currentAction == CurrentAction.answer2)
        {
            Answer2(CombatButton);
        }

        if(currentAction == CurrentAction.answer3)
        {
            Answer3(CombatButton);
        }
    }


    void StartGame(UIButtons button)
    {
        button.PLAY();
        Debug.Log("StartGame pressed");
    }

    void Controls(UIButtons button)
    {
        button.KEYMAP();
        Debug.Log("Controls pressed");
    }

    void QuitGame(UIButtons button)
    {
        button.EXIT();
        Debug.Log("QuitGame pressed");
    }

    void ResetLevel(UIButtons button)
    {
        button.RESETLEVEL();
        Debug.Log("Reset Level pressed");
    }

    void Resume(UIButtons button)
    {
        button.PLAY();
        Debug.Log("Resume pressed");
    }

    void MainMenu(UIButtons button)
    {
        button.MAINMENU();
        Debug.Log("Main Menu pressed");
    }

    void VolumeSlider(UIButtons button)
    {
        button.VOLUME();
        Debug.Log("Volume Slider pressed");
    }

    void EasterEgg(UIButtons button)
    {
        button.EASTEREGG();
        Debug.Log("Easter Egg pressed");
    }

    void GoBack(UIButtons button)
    {
        button.CLOSE();
        Debug.Log("GoBack pressed");
    }

    void Answer1(UICombat button)
    {
        button.Answer1();
        Debug.Log("an1");
    }

    void Answer2(UICombat button)
    {
        button.Answer2();
        Debug.Log("an2");
    }

    void Answer3(UICombat button)
    {
        button.Answer3();
        Debug.Log("an3");
    }
}
