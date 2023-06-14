using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wisp : MonoBehaviour
{
    [SerializeField] Transform followPoint;
    [SerializeField] float floatingFrequency = 1f;
    [SerializeField] float floatingAmount = 1f;
    [SerializeField] Transform mesh;
    public bool isInTotem;

    private Transform agentTransform;
    private float height;

    private float seed;
    private float floatingOffset;
    //private void Awake()
    //{
    //    agentTransform = agent.transform;
    //    agentTransform.parent = transform.parent;
    //    Vector3 position = agentTransform.position;
    //    //position.y = 0;
    //    agentTransform.position = position;
    //    agent.FollowPoint = followPoint;
    //    height = transform.position.y;

    //    seed = Random.Range(0, Mathf.PI * 2);
    //}

    //private void Update()
    //{
    //    

    //}
    private NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        height = mesh.position.y;
    }

    private void Update()
    {
        agent.SetDestination(followPoint.position);

        floatingOffset += Time.deltaTime;


        Vector3 position = mesh.position;
        position.y = height + Mathf.Sin((seed + floatingOffset) * floatingFrequency) * floatingAmount;
        mesh.position = position;
    }

    public void GoToTotem(Totem totem)
    {

    }
}
