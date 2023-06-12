using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputManager iM;
    Rigidbody rb;

    [SerializeField] Transform cam;


    Vector3 movement;
    Vector3 offset;
    [SerializeField]float speed;
    bool isMoving;
    void Start()
    {
        iM = GameManager.Instance.IM;
        rb = GetComponent<Rigidbody>();
        offset = new Vector3(1, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        MoveInputs();
    }

    private void FixedUpdate()
    {
        MovePlayer(movement);
    }


    void MoveInputs()
    {
        movement = new Vector3(iM.MoveHor.ReadValue<float>(), 0, iM.MoveVert.ReadValue<float>()).normalized;
        movement = rb.rotation * movement;
    }

    void MovePlayer(Vector3 dir)
    {
        rb.velocity = dir * speed * Time.fixedDeltaTime;
    }


}
