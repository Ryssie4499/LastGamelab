using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum TypeOfWisp
{
    Fire,
    Ice,
    Rock
}
public class Wisp : MonoBehaviour
{
    public TypeOfWisp typeOfWisp;
    [SerializeField] Transform followPoint;
    [SerializeField] float floatingFrequency = 1f;
    [SerializeField] float floatingAmount = 1f;

    [SerializeField] private float degreesPerSecond = 45;

    [SerializeField] Transform mesh;
    public bool isInTotem;
    public Transform TotemSphere;

    public GameObject Player;
    public bool hasStopped;

    private Transform agentTransform;
    private float height;

    private float seed;
    private float floatingOffset;
    public Coroutine coOrbitate;

    private NavMeshAgent agent;
    Rigidbody playerRB;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerRB = Player.GetComponent<Rigidbody>();
        height = mesh.position.y;
    }

    private void Update()
    {
        if (isInTotem)
        {
            agent.SetDestination(TotemSphere.position);
        }
        else
        {
            floatingOffset += Time.deltaTime;


            Vector3 position = mesh.position;
            position.y = height + Mathf.Sin((seed + floatingOffset) * floatingFrequency) * floatingAmount;
            mesh.position = position;

            #region orbitate
            //se il player non si muove (non prendeva 0 perchè si muoveva sempre di un millimetro senza che toccassi niente) fa partire il timer di 5 secondi
            if (playerRB.velocity.magnitude >= 0 && playerRB.velocity.magnitude <= 0.1f && coOrbitate == null)
            {
                coOrbitate = StartCoroutine(TimeToOrbitate());
            }
            else if (playerRB.velocity.magnitude > 0.1f && coOrbitate != null)
            {
                StopCoroutine(coOrbitate /*TimeToOrbitate()*/);
                coOrbitate = null;
                hasStopped = false;
            }

            //se si muove prende la tua destinazione
            if (!hasStopped)
            {
                agent.SetDestination(followPoint.position);

            }
            //se non si muove orbita
            else
                Orbitate();
            #endregion

        }
    }

    public void GoToTotem(Transform totemPoint)
    {
        TotemSphere = totemPoint;
        isInTotem = true;
    }

    public void ReturnToPlayer()
    {
        isInTotem = false;
    }

    #region orbitate
    //gli resetto la destinazione e lo faccio ruotare attorno al player sull'asse y di 45° al secondo
    public void Orbitate()
    {
        agent.ResetPath();
        transform.RotateAround(Player.transform.position, Vector3.up, degreesPerSecond * Time.deltaTime);
    }

    //timer di cinque secondi, dopo quel lasso di tempo, si rende conto di essere fermo da troppo
    IEnumerator TimeToOrbitate()
    {
        yield return new WaitForSeconds(5);
        hasStopped = true;
    }
    #endregion
}
