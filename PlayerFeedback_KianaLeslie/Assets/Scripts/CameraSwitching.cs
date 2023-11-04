using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    public GameObject cameraScreen; 
    public GameObject blackScreen; 

    public float switchInterval = 5.0f; 

    private bool isCameraActive = true;

    private void Start()
    {
        cameraScreen.SetActive(true);
        blackScreen.SetActive(false);

        InvokeRepeating("SwitchCamera", switchInterval, switchInterval);
    }

    private void SwitchCamera()
    {
        isCameraActive = !isCameraActive;
        cameraScreen.SetActive(isCameraActive);
        blackScreen.SetActive(!isCameraActive);
    }
}