using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputManager iM;
    Rigidbody rb;


    Vector3 movement;
    [SerializeField]float speed;
    void Start()
    {
        iM = GameManager.Instance.IM;
        rb = GetComponent<Rigidbody>();
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
    }

    void MovePlayer(Vector3 dir)
    {
        rb.velocity = dir * speed * Time.fixedDeltaTime;
    }
}
