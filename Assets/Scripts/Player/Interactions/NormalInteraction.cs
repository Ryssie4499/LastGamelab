using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalInteraction : Interaction
{
    private void Update()
    {
        Normal();
    }

    private void Normal()
    {
        if (!inputManager.Interact.triggered) return;
        Collider collider = GetClosestInteractable();
        if (collider == null)
        {
            return;
        }

        INormalable normalable = collider.GetComponent<INormalable>();

        if (normalable != null)
        {
            normalable.NormalInteraction();
        }
    }
}
