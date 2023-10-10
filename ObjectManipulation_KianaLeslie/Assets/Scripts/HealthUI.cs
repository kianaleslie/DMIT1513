using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    int maxHealth;
    int health;

    [SerializeField] Image healthUI;

    void Start()
    {
        maxHealth = 30;
        health = maxHealth;
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        healthUI.transform.localScale = new Vector3(health / (float)maxHealth, 1, 1);

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}