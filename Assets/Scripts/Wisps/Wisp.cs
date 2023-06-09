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
    public bool isInCombat;
    public Transform TotemSphere;
    //public Transform enemyPos;
    public bool attack;

    public GameObject Player;
    public bool hasStopped;
    private Transform agentTransform;
    public Transform attackPosition;
    private float height;

    float timer;

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
        if (isInTotem && !isInCombat)
        {
            agent.SetDestination(TotemSphere.position);
        }
        else if (!isInTotem && !isInCombat)
        {
            floatingOffset += Time.deltaTime;


            Vector3 position = mesh.position;
            position.y = height + Mathf.Sin((seed + floatingOffset) * floatingFrequency) * floatingAmount;
            mesh.position = position;

            #region orbitate
            //se il player non si muove (non prendeva 0 perch� si muoveva sempre di un millimetro senza che toccassi niente) fa partire il timer di 5 secondi
            if (playerRB.velocity.magnitude >= 0 && playerRB.velocity.magnitude <= 0.1f && coOrbitate == null)
            {
                coOrbitate = StartCoroutine(TimeToOrbitate());
            }
            else if (playerRB.velocity.magnitude > 0.1f && coOrbitate != null)
            {
                StopCoroutine(coOrbitate);
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
        else if (isInCombat)
        {
            floatingOffset += Time.deltaTime;

            Vector3 position = mesh.position;
            position.y = height + Mathf.Sin((seed + floatingOffset) * floatingFrequency) * floatingAmount;
            mesh.position = position;
            if (!attack)
                agent.SetDestination(followPoint.position);
            if(attack)
            {
                agent.SetDestination(attackPosition.position);
                timer += Time.deltaTime;
                if (timer >= 1f)
                {
                    attack = false;
                    timer = 0f;
                }
            }
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
    //gli resetto la destinazione e lo faccio ruotare attorno al player sull'asse y di 45� al secondo
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
        agent.enabled = false;
        agent.transform.position = followPoint.position;

        Invoke(nameof(NavMeshTimer), 1);
    }
    
    void NavMeshTimer()
    {
        isInTotem = false;
        agent.SetDestination(followPoint.position);
        agent.enabled = true; 
    }
}
