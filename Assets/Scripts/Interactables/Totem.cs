using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Totem : MonoBehaviour
{
    [SerializeField] private Transform wispRestingPoint;
    [SerializeField] private Door door;

    public Transform WispRestingPoint { get => wispRestingPoint; }

    public void Activate()
    {
        door.Open();

    }
    public void Deactivate()
    {
        door.Close();
    }

#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField] private bool showGizmos;

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        if (door != null)
        {
            Handles.color = Color.green;
            Handles.DrawDottedLine(transform.position, door.transform.position, 3f);
        }
    }
#endif
}
