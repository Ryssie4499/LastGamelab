using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInteraction : Interaction
{
    void Update()
    {
        Rock();
    }

    private void Rock()
    {
        if (inputManager.Rock.ReadValue<float>() < 1f) return;

        Collider collider = GetClosestInteractable();

        if (collider == null)
        {
            return;
        }

        IRockable rockable = collider.GetComponent<IRockable>();

        if (rockable != null)
        {
            rockable.Rock();
        }
    }
}
