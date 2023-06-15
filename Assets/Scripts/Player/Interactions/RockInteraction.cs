using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RockInteraction : WispInteraction
{
    protected override InputAction GetButton()
    {
        return inputManager.Rock;
    }

    protected override void Interact(Collider collider)
    {
        IRockable rockable = collider.GetComponent<IRockable>();

        if (rockable != null)
        {
            rockable.Rock();
        }
    }
}
