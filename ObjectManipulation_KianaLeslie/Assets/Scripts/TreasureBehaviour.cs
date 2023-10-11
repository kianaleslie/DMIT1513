using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreasureBehaviour : MonoBehaviour
{
    [SerializeField] GameObject chest;
    [SerializeField] GameObject chestLock;
    [SerializeField] GameObject coins;
    public MapBehaviour item;
   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            chest.SetActive(false);
            chestLock.SetActive(false);
            StartCoroutine("Wait");
            item.ChestCollected();
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        coins.SetActive(false);
    }
}