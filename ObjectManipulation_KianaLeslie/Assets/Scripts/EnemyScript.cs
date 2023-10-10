using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    //int maxHealth;
    //int health;

    ////[SerializeField] Image healthUI;
    ////[SerializeField] TMP_Text healthValue;
    //[SerializeField] HealthUI healthBar;

    //private void Awake()
    //{
    //    healthBar = GetComponent<HealthUI>();
    //}
    //void Start()
    //{
    //    maxHealth = 50;
    //    health = maxHealth;
    //    healthBar.UpdateHealthBar(health, maxHealth);
    //    //healthValue.text = health.ToString();
    //}

    //public void DealDamage(int damage)
    //{
    //    health -= damage;
    //    //healthUI.transform.localScale = new Vector3(health / (float)maxHealth, 1, 1);
    //    //healthValue.text = health.ToString();
    //    healthBar.UpdateHealthBar(health, maxHealth);
    //    if (health <= 0)
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}


    //[SerializeField] float health;
    //[SerializeField] float maxHealth = 30;

    //private void Start()
    //{
    //    health = maxHealth;
    //}
    //public void TakeDamage(float damage)
    //{
    //    health -= damage;
    //    if (health <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}
}