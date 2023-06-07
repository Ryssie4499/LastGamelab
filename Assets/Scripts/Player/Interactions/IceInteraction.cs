using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceInteraction : Interaction
{

    void Update()
    {
        Ice();
    }

    private void Ice()
    {
        if (!Input.GetKeyDown(KeyCode.E))
        {
            return;
        }


        Collider collider = GetClosestInteractable();

        Debug.Log(collider.name);
        if (collider == null)
        {
            return;
        }

        IIceable iceable = collider.GetComponent<IIceable>();

        if (iceable == null)
        {
            return;
        }

        if (iceable.IsIced)
        {
            iceable.UnIce();
        }
        else
        {
            iceable.Ice();
        }
    }
}
