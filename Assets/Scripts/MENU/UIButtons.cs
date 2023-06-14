using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public GameObject StartMenu, PauseMenu, EndMenu, EasterEggMenu, KeymapMenu, USureMenu;
    public void EXIT()
    {
        Application.Quit();
    }
    public void PLAY()
    {
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
}
