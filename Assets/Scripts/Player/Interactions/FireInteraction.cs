using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInteraction : Interaction
{
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (inputManager.Fire.ReadValue<float>() < 1f) return;

        Collider collider = GetClosestInteractable();

        if (collider == null)
        {
            return;
        }

        IFireable fireable = collider.GetComponent<IFireable>();

        if (fireable != null)
        {
            fireable.Fire();
        }
    }
}
