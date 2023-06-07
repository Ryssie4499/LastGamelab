using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("In Game Controls")]

    public InputAction MoveHor;
    public InputAction MoveVert;
    public InputAction Fire;
    public InputAction Ice;
    public InputAction Rock;
    public InputAction Pause;


    [Header("Menu Controls")]

    public InputAction Select;
    public InputAction Back;




    private void OnEnable()
    {
        MoveHor.Enable();
        MoveVert.Enable();
        Fire.Enable();
        Ice.Enable();
        Rock.Enable();
        Select.Enable();
        Back.Enable();
        Pause.Enable();
    }


    private void OnDisable()
    {
        MoveHor.Disable();
        MoveVert.Disable();
        Fire.Disable();
        Ice.Disable();
        Rock.Disable();
        Select.Disable();
        Back.Disable();
        Pause.Disable();
    }

}
