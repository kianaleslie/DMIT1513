using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonScript : MonoBehaviour
{
    public InputAction zoomAction;
    Vector2 zoomValue;

    float zoom;
    float zoomMultiplier = 4.0f;
    float minZoom = 3.0f;
    float maxZoom = 6.0f;
    float velocity = 0f;
    float time = 0.25f;

    [SerializeField] Camera cam;
    private void Start()
    {
        zoom = cam.orthographicSize;
    }

    private void Update()
    {
        zoomValue = zoomAction.ReadValue<Vector2>();
        zoom -= zoomValue.y * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, time);
    }
    private void OnEnable()
    {
        zoomAction.Enable();
    }
    private void OnDisable()
    {
        zoomAction.Disable();
    }
    //camera zoom ref:
    //https://www.youtube.com/watch?v=HxnpWhxjJwE
}