using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PressurePlateOpener : MonoBehaviour
{
    private enum Mode
    {
        DefaultOpen,
        DefaultClosed
    }

    [SerializeField] PressurePlate[] pressurePlates;
    [SerializeField] Mode mode;

    private IOpenable openable;

    private bool lastActive;
    private bool lastUnactive;
   

    private void Awake()
    {
        openable = GetComponent<IOpenable>();
    }

    private void Update()
    {
        int numberOfTouching = 0;

        foreach (var plate in pressurePlates)
        {
            if(plate.IsTouching) numberOfTouching++;
        }

        if (numberOfTouching == pressurePlates.Length)
            Activate();
        else
            Deactivate();

    }

    private void Activate()
    {
        if (lastActive) return;

        if(mode == Mode.DefaultClosed)
            openable.Open();
        else
            openable.Close();

        lastActive = true;
        lastUnactive = false;
    }

    private void Deactivate()
    {
        if (lastUnactive) return; 

        if (mode == Mode.DefaultClosed)
            openable.Close();
        else
            openable.Open();

        lastActive = false;
        lastUnactive = true;
    }

#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField] private bool showGizmos;

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        Handles.color = Color.green;
        foreach (var pressurePlate in pressurePlates) 
        {
            Handles.DrawDottedLine(transform.position, pressurePlate.transform.position, 2f);
        }
    }
#endif
}
