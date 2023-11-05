using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSwitchesCams : MonoBehaviour
{
    public GameObject cameraScreen;
    public GameObject blackScreen;
    public AudioSource crashingSound;
    public ParticleSystem smoke;
    public GameObject scaryFaceObject;
    public GameObject playerPos;
    public Light smallRoomLight;
    public Light mainRoomLight;
    public Light consoleLight;
    public Light scaryFaceLight;
    public GameObject boxLight;

    private bool isCameraActive = true;
    private bool hasSwitched = false;
    
    void OnMouseDown()
    {
        isCameraActive = !isCameraActive;
        cameraScreen.SetActive(isCameraActive);
        blackScreen.SetActive(!isCameraActive);

        if (!hasSwitched)
        {
            crashingSound.Play();
            hasSwitched = true;
            smoke.Play();
            StartCoroutine(ActivateScaryFace());
            StartCoroutine(TurnOffLights());
            StartCoroutine(EndGame());
        }
    }
    IEnumerator ActivateScaryFace()
    {
        yield return new WaitForSeconds(3.0f); 
        scaryFaceObject.SetActive(true);
        scaryFaceObject.GetComponent<ScaryFaceMovement>().player = playerPos;
        scaryFaceObject.GetComponent<AudioSource>().Play();
    }
    IEnumerator TurnOffLights()
    {
        yield return new WaitForSeconds(4.0f);
        smallRoomLight.gameObject.SetActive(false);
        mainRoomLight.gameObject.SetActive(false);
        consoleLight.gameObject.SetActive(false);
        scaryFaceLight.gameObject.SetActive(false);
        boxLight.gameObject.SetActive(false);
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(6.0f);
        GameSceneManager.QuitGame();
    }
}