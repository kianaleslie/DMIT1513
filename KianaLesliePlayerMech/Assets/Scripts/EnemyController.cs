using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPoints;
    int index = 0;
    public NavMeshAgent agent;
    public float speed = 5.0f;

    void Start()
    {
        agent.speed = speed;
        SetDestination();
    }
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            index = (index + 1) % patrolPoints.Length;
            SetDestination();
        }
    }
    void SetDestination()
    {
        agent.speed = speed;
        agent.SetDestination(patrolPoints[index].position);
    }
}