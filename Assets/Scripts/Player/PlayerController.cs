using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputManager iM;
    Rigidbody rb;



    Vector3 movement;
    Vector3 offset;
    [SerializeField] float speed;
    public float rotationSpeed;

    [SerializeField] Transform mesh;
[SerializeField] Animator anim;

    void Start()
    {
        iM = GameManager.Instance.IM;
        rb = GetComponent<Rigidbody>();
        offset = new Vector3(1, 0, 1);
    }

    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.inGame)
            MoveInputs();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.inGame)
        {
            MovePlayer(movement);
           rotatrCar(movement);

        }
       moveAnim();
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

    private void OnEnable()
    {
        UIButtons.OnReset += Reset;
    }

    private void OnDisable()
    {
        UIButtons.OnReset -= Reset;
    }

    public void Reset()
    {
        rb.MovePosition(ResetArea.CurrentResetArea.playerResetPoint.position);
    }

    void rotatrCar(Vector3 dir)
    {
        if (Mathf.Abs(iM.MoveHor.ReadValue<float>()) == 1 || Mathf.Abs(iM.MoveVert.ReadValue<float>()) == 1)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            mesh.rotation = Quaternion.RotateTowards(mesh.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void moveAnim()
    {
        if ((GameManager.Instance.gameState == GameManager.GameState.inGame))
        {
            if (Mathf.Abs(iM.MoveHor.ReadValue<float>()) == 1 || Mathf.Abs(iM.MoveVert.ReadValue<float>()) == 1)
            {
                anim.SetBool("Moving", true);
            }
            else
            {
                anim.SetBool("Moving", false);
            }
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }
}
