using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MapBehaviour : MonoBehaviour
{
   
    public Image mapImage;
    public Image youAreHereImage;
    public Image xImage;
    public TMP_Text youAreHereText;
    public TMP_Text xText;
    public TMP_Text itemCountText;

     int itemCount = 0;
    int enemyCount = 3; 

    private void Start()
    {
        mapImage.enabled = false;
        youAreHereImage.enabled = false;
        xImage.enabled = false;
        youAreHereText.enabled = false;
        xText.enabled = false;

        //initialize the UI text with the item count
        UpdateItemCountText();
    }

    public void EnemyDefeated()
    {
        // Called when an enemy is defeated.
        enemyCount--;

        // Check if the player has defeated all 3 enemies.
        if (enemyCount == 0)
        {
            // Show the map image when all 3 enemies are defeated.
            mapImage.enabled = true;
            youAreHereImage.enabled = true; 
            xImage.enabled = true;
            youAreHereText.enabled = true;
            xText.enabled = true;   
            itemCount = 1;
        }

        // Update the UI Text with the current item count.
        UpdateItemCountText();
    }

    private void UpdateItemCountText()
    {
        itemCountText.text = "Items: " + itemCount.ToString();
    }
}