using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction rotateAction;
    Vector2 moveValue;
    Vector2 rotateValue;
    float moveSpeed;
    float rotateSpeed;

    bool isRotating;
    public Transform player;
    public Transform followPlayer;
    public NavMeshAgent followerAgent;
    public float followDistance = 2.0f;

    //public Camera cam;
    //public NavMeshAgent agent;
    void Start()
    {
        moveSpeed = 10.0f;
        rotateSpeed = 150.0f;
    }

    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();

        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }
        if (isRotating)
        {
            transform.Rotate(Vector3.up, rotateValue.x * rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime);
        }

        FollowPlayer();
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if(Physics.Raycast(ray, out hit))
        //    {
        //        agent.SetDestination(hit.point);
        //    }
        //}
    }
    void FollowPlayer()
    {
        Vector3 targetPosition = player.position - player.forward * followDistance;
        followerAgent.SetDestination(targetPosition);
    }
    private void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
    }

}





//commented code from brackeys : https://www.youtube.com/watch?v=CHV1ymlw-P8