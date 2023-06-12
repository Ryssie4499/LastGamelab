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
    public InputAction Interact;


    [Header("Menu Controls")]

    public InputAction Select;
    public InputAction Back;
    public InputAction downMenu;
    public InputAction UpMenu;


    [Header("Any controll")]

    public InputAction AnyKeybord;
    public InputAction AnyPad;


    //Button Bools

    public bool anyKeybord;
    public bool anyPad;
    public bool usingKeybord;





    private void Awake()
    {

        // controls Detection
        AnyKeybord.started += context => anyKeybord = true;
        AnyKeybord.performed += context => anyKeybord = true;
        AnyKeybord.canceled += context => anyKeybord = false;

        AnyPad.started += context => anyPad = true;
        AnyPad.performed += context => anyPad = true;
        AnyPad.canceled += context => anyPad = false;
    }

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
        AnyKeybord.Enable();
        AnyPad.Enable();
        Interact.Enable();
        UpMenu.Enable();
        downMenu.Enable();
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
        AnyKeybord.Disable();
        AnyPad.Disable();
        Interact.Disable();
        UpMenu.Disable();
        downMenu.Disable();
    }




    private void Update()
    {
        ControllerDetection();
    }

    void ControllerDetection()
    {
        if(anyKeybord)
        {
            usingKeybord = true;
        }
        else if(anyPad)
        {
            usingKeybord = false;
        }
    }

}
