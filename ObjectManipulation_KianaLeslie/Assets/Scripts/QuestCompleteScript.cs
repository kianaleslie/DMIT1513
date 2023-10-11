using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCompleteScript : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject cube;
    public CameraSwitcher sideCam;

    private void Start()
    {
        uiObject.SetActive(false);
        cube.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            sideCam.StartInteraction();
            StartCoroutine("Wait");
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        uiObject.SetActive(false);
        sideCam.EndInteraction();
        cube.SetActive(false);
        Application.Quit();
    }
}
