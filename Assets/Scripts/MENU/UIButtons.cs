using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class UIButtons : MonoBehaviour
{
    InputManager iM;
    private static UIButtons _instance;

    public GameObject StartMenu, PauseMenu, EndMenu, EasterEggMenu, KeymapMenu, USureMenu, VolumeMenu;
    public static UIButtons Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log(_instance);
            }
            return _instance;
        }
    }
    void Start()
    {
        iM = GameManager.Instance.IM;
    }
    private void Update()
    {
        if (iM.Pause.triggered && GameManager.Instance.gameState == GameManager.GameState.inGame)
        {
            GameManager.Instance.gameState = GameManager.GameState.inMenu;
            PauseMenu.SetActive(true);
        }
        else if (GameManager.Instance.gameState == GameManager.GameState.inMenu && iM.Pause.triggered)
        {
            PLAY();
        }
    }
    public void EXIT()
    {
        Application.Quit();
    }
    public void PLAY()
    {
        StartMenu.SetActive(false);
        PauseMenu.SetActive(false);
        GameManager.Instance.gameState = GameManager.GameState.inGame;
    }
    public void KEYMAP()
    {
        KeymapMenu.SetActive(true);
    }
    public void EASTEREGG()
    {
        EasterEggMenu.SetActive(true);
    }
    //public void USURE()
    //{
    //    USureMenu.SetActive(true);


    public static Action OnReset;
    public void RESETLEVEL()
    {
        if(ResetArea.CurrentResetArea)
        {
            ResetArea.CurrentResetArea.Reset();
            OnReset?.Invoke();
        }
    }

    public void MAINMENU()
    {
        USureMenu.SetActive(true);
    }
    public void IMSURE()
    {
        
    }
    public void VOLUME()
    {
        VolumeMenu.SetActive(true);
    }
    public void CLOSE()
    {
        VolumeMenu.SetActive(false);
        USureMenu.SetActive(false);
        KeymapMenu.SetActive(false);
    }
}
