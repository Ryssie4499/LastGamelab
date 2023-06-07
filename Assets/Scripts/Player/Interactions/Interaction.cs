using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    [SerializeField] private LayerMask interactMask;
    [SerializeField] private float range;

    protected Collider GetClosestInteractable()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, interactMask);
        if (colliders.Length == 0) return null;

        Collider closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            float distance = Vector3.Distance(transform.position, collider.transform.position);

            if (distance < closestDistance)
            {
                closest = collider;
                closestDistance = distance;
            }
        }

        return closest;
    }

#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField] private bool showGizmos;
    [SerializeField] private Color gizmosColor;
    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        Gizmos.color = gizmosColor;
        Gizmos.DrawWireSphere(transform.position, range);
    }
#endif
}