using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    [SerializeField] private LayerMask interactMask;
    [SerializeField] private Vector3 hitboxPosition;
    [SerializeField] private Vector3 hitboxDimension;

    protected InputManager inputManager;

    private void Start()
    {
        inputManager = GameManager.Instance.IM;
    }

    protected Collider GetClosestInteractable()
    {
        Collider[] colliders = Physics.OverlapBox(CalculateHitboxPosition(), hitboxDimension, transform.rotation, interactMask);
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

    private Vector3 CalculateHitboxPosition()
    {
        return transform.position + transform.right * hitboxPosition.x + transform.up * hitboxPosition.y + transform.forward * hitboxPosition.z;
    }

#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField] private bool showGizmos;
    [SerializeField] private Color gizmosColor;
    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        Gizmos.color = gizmosColor;
        Gizmos.DrawWireCube(CalculateHitboxPosition(), hitboxDimension);
    }
#endif
}
