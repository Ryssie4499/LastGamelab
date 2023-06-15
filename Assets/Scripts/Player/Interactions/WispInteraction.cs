using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class WispInteraction : Interaction
{
    [SerializeField] protected Wisp wisp;

    private InputAction action;

    private Totem activeTotem;

    protected new void Start()
    {
        base.Start();
        action = GetButton();
    }

    void Update()
    {
        if (!action.triggered) return;

        Collider collider = GetClosestInteractable();

        if (collider == null)
        {
            return;
        }

        if (collider.CompareTag("Totem"))
        {
            Totem(collider);
        }
        else if (!wisp.isInTotem)
        {
            Interact(collider);
        }
    }

    private void Totem(Collider collider)
    {
        Totem totem = collider.GetComponent<Totem>();

        if (totem == null) return;


        if (!wisp.isInTotem)
        {
            wisp.GoToTotem(totem.WispRestingPoint);
            totem.Activate();
            activeTotem = totem;
        }
        else
        {
            // check if it is the same totem
            if(totem == activeTotem)
            {
                // retrieve wisp
                wisp.ReturnToPlayer();
                totem.Deactivate();
            }
        }
    }
    protected abstract InputAction GetButton();

    protected abstract void Interact(Collider collider);



}
