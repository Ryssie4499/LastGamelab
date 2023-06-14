using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestructable : MonoBehaviour, IRockable
{
    [SerializeField] Animator animator;

    BoxCollider collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }

    public void Rock()
    {
        animator.SetTrigger("Destroy");
        collider.enabled = false;
    }
}
