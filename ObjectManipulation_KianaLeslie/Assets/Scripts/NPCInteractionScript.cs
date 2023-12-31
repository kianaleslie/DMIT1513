using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCInteractionScript : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject cube;
    
    private void Start()
    {
        //start not showing ui 
        uiObject.SetActive(false);
        cube.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //show ui 
            uiObject.SetActive(true);
            //starts a IEnumerator - uses real time secs 
            StartCoroutine("Wait");
        }    
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        uiObject.SetActive(false);
        cube.SetActive(false);
    }

    //text appear reference: https://www.youtube.com/watch?v=CNNeD9oT4DY
}