using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GameOverManager : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject cube;
    public Camera gameOverCam;
    public Camera cam;

    void Start()
    {
        uiObject.SetActive(false);
        cube.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Friend"))
        {
            gameOverCam.depth = 5;
            cam.depth = -5;
            uiObject.SetActive(true);
            StartCoroutine("Wait");
        }
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        uiObject.SetActive(false);
        cube.SetActive(false);
    }
}