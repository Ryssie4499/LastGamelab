using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IceInteraction : WispInteraction
{
    protected override InputAction GetButton()
    {
        return inputManager.Ice;
    }

    protected override void Interact(Collider collider)
    {
        
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
