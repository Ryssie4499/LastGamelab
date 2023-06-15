using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableCube : MonoBehaviour, IIceable
{

    [SerializeField] bool ignoreInputWhenOnPressurePlate;
    public bool IsIced { get => isIced; set => isIced = value; }

    private bool isIced;
    private bool ignoreInput;

    private Rigidbody body;
    private Animator animator;

    private bool onPressurePlate;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    public void Ice()
    {
        if (isIced || ignoreInput || onPressurePlate) return;
        ignoreInput = true;

        animator.SetTrigger("Ice");

        Debug.Log("icee");
    }

    public void UnIce()
    {
        if (!isIced || ignoreInput) return;
        ignoreInput = true;
        body.mass = 100000f;
        //body.velocity = Vector3.zero;
        animator.SetTrigger("UnIce");
        //Debug.Log("unicee");
    }

    public void AnimationIce()
    {
        body.mass = 1;
        isIced = true;
        ignoreInput = false;
    }

    public void AnimationUnIce()
    {
        //Debug.Log("done");
        isIced = false;
        ignoreInput = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PressurePlate"))
        {
            UnIce();

            if(ignoreInputWhenOnPressurePlate)
                onPressurePlate = true;
        }
    }
}
