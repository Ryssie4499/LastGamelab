using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;


    public static GameManager Instance
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


    public enum GameState 
    { 
        inMenu,
        inGame,
        inCombat
    }

    public GameState gameState = GameState.inMenu;

    InputManager _iM;
    CamManager _cM;



    private void Awake()
    {
        _instance = this;


        _iM = FindObjectOfType<InputManager>();
        _cM= FindObjectOfType<CamManager>();
    }




    private void Update()
    {
        controlMouse();
    }



    public InputManager IM { get { return _iM; } set { _iM = value; } }
    public CamManager CM { get { return _cM; } set { _cM = value; } }

    void controlMouse()
    {
        if(gameState == GameState.inGame)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            if(IM.usingKeybord)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

}

