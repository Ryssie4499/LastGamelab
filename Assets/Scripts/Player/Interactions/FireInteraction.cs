using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireInteraction : WispInteraction
{
    protected override InputAction GetButton()
    {
        return inputManager.Fire;
    }

    protected override void Interact(Collider collider)
    {
        IFireable fireable = collider.GetComponent<IFireable>();

        if (fireable != null)
        {
            fireable.Fire();
        }
    }
}
