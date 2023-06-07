using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private LayerMask colliderMask;
    [SerializeField] private float radius;

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

    public bool IsTouching { get; private set; }


    private void FixedUpdate()
    {
        IsTouching = Physics.CheckSphere(transform.position, radius, colliderMask, QueryTriggerInteraction.Ignore);

        /*
        if (IsTouching && !lastTouching)
            audioSource.PlayOneShot(interactClip);

        lastTouching = IsTouching;
        */
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
