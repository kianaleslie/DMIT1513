using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    //health variables
    int maxHealth;
    int currentHealth;

    [SerializeField] Image healthUI;
    void Start()
    {
        maxHealth = 20;
        currentHealth = maxHealth;
    }
    void Update()
    {
        
    }
    void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.transform.localScale = new Vector3(currentHealth / maxHealth, 1, 1);

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}