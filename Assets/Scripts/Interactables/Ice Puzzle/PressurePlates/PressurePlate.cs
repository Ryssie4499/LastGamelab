using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private LayerMask colliderMask;
    [SerializeField] private float radius;

    [SerializeField, ColorUsage(true, true)] private Color litColor;
    [Header("References")]
    [SerializeField] private MeshRenderer[] renderes;
    [SerializeField] private int materialPosition = 1;

    private Material[] materials;
    private Color baseColor;
    /*
    [Header("Audio")]
    [SerializeField] private AudioClip interactClip;
    

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private bool lastTouching;
    */

    private void Awake()
    {
        for (int i = 0; i < renderes.Length; i++)
        {
            materials[i] = renderes[i].materials[materialPosition];
        }


        baseColor = materials[0].GetColor("_EColor");
    }

    public bool IsTouching { get; private set; }


    private void ChangeMaterial(Color color)
    {
        foreach (var material in materials)
        {
            material.SetColor("_EColor", color);
        }
    }

    private bool up;
    private bool down;
    private bool lastTouching;
    private void FixedUpdate()
    {
        IsTouching = Physics.CheckSphere(transform.position, radius, colliderMask, QueryTriggerInteraction.Ignore);


        if (IsTouching && !lastTouching)
        {
            ChangeMaterial(litColor);
        }

        if(!IsTouching && lastTouching)
        {
            ChangeMaterial(baseColor);
        }

        lastTouching = IsTouching;
    }

#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField] private bool showGizmos;

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
#endif
}
