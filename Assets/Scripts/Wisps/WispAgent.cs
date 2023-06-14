using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WispAgent : MonoBehaviour
{
    public Transform FollowPoint;

    private NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if(FollowPoint != null)
        {
            agent.SetDestination(FollowPoint.position);
        }
    }
}
