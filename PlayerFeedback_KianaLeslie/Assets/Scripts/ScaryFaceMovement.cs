using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryFaceMovement : MonoBehaviour
{
    public GameObject player;

    public float moveSpeed = 5f;

    private void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}