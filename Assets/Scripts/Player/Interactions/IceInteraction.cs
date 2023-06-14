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
        if (inputManager.Ice.ReadValue<float>() < 1f) return;

        Collider collider = GetClosestInteractable();

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
