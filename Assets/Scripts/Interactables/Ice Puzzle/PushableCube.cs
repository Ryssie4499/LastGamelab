using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableCube : MonoBehaviour, IIceable
{
    public bool IsIced { get => isIced; set => isIced = value; }

    private bool isIced;
    private bool ignoreInput;

    private Rigidbody body;
    private Animator animator;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    public void Ice()
    {
        if (isIced || ignoreInput) return;
        ignoreInput = true;
        animator.SetTrigger("Ice");
    }

    public void UnIce()
    {
        if (!isIced || ignoreInput) return;
        ignoreInput = true;
        animator.SetTrigger("UnIce");

    }

    public void AnimationIce()
    {
        body.mass = 1;
        isIced = true;
        ignoreInput = false;
    }

    public void AnimationUnIce()
    {
        body.mass = 1000000f;
        isIced = false;
        ignoreInput = false;
    }
}
