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

    [SerializeField] public Transform mesh;
[SerializeField] Animator anim;

    UICombat ui;
    void Start()
    {
        iM = GameManager.Instance.IM;
        rb = GetComponent<Rigidbody>();
        ui = FindObjectOfType<UICombat>();
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Area1"))
        {
            ui.zona = Area.Bambino;
        }
        else if(other.CompareTag("Area2"))
        {
            ui.zona = Area.Madre;
        }
        else if(other.CompareTag("Area2"))
        {
            ui.zona = Area.Padre;
        }
    }
}
