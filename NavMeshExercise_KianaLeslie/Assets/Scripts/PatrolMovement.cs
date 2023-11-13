using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    int index = 0;
    public NavMeshAgent agent;

    void Start()
    {
        SetDestination();
    }
    void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            index = (index + 1) % patrolPoints.Length;
            SetDestination();
        }
    }
    void SetDestination()
    {
        agent.SetDestination(patrolPoints[index].position);
    }
}