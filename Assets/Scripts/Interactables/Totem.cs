using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Totem : MonoBehaviour
{
    [SerializeField] private Transform wispRestingPoint;
    [SerializeField] private Door door;

    [SerializeField, ColorUsage(true, true)] private Color litColor;

    [Header("References")]
    [SerializeField] private MeshRenderer ballRenderer;
    [SerializeField] private int ballMaterialPosition = 1;

    public Transform WispRestingPoint { get => wispRestingPoint; }

    private Vector4 baseColor;
    private Material sphereMaterial;
    private void Awake()
    {
        sphereMaterial = ballRenderer.materials[ballMaterialPosition];

        baseColor = sphereMaterial.GetColor("_EColor");
    }

    public void Activate()
    {
        if(door != null)
            door.Open();
        sphereMaterial.SetColor("_EColor", litColor);
    }
    public void Deactivate()
    {
        if(door != null)
            door.Close();

        sphereMaterial.SetColor("_EColor", baseColor);
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
