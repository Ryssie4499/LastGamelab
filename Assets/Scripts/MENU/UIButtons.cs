using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    private static UIButtons _instance;

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

    public GameObject StartMenu, PauseMenu, EndMenu, EasterEggMenu, KeymapMenu, USureMenu, VolumeMenu;
    public void EXIT()
    {
        Application.Quit();
    }
    public void PLAY()
    {
        StartMenu.SetActive(false);
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
    public void USURE()
    {
        USureMenu.SetActive(true);
    }
    public void RESETLEVEL()
    {

    }
    public void MAINMENU()
    {
        SceneManager.LoadScene(0);
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
