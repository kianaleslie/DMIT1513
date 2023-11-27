using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToyMovement : MonoBehaviour
{
    public Transform meetingPoint;
    public NavMeshAgent agent;
    public float speed = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SetDestination();
        }
    }
    void SetDestination()
    {
        agent.speed = speed;
        agent.SetDestination(meetingPoint.position);
    }
}