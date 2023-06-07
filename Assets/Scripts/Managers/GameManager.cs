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
    }

    public GameState gameState = GameState.inMenu;

    InputManager _iM;



    private void Awake()
    {
        _instance = this;


        _iM = FindObjectOfType<InputManager>();
    }


    





    public InputManager IM { get { return _iM; } set { _iM = value; } }

}

