using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PaintballScript : MonoBehaviour
{
    /*  - Only objects that have been tagged Paintable will be affected by the paint ball *******************************************************************************
        - Place a number of Paintable objects in the area ***************************************************************************************************************
        - Add a player object that can move forward, backward, left, and right with WASD ********************************************************************************
        - Have the player rotate with the mouse *************************************************************************************************************************
        - Move the camera to a first person view on the player **********************************************************************************************************
        - Attach the camera and the paintball gun to an empty game object that will pivot up and down *******************************************************************
          with the mouse ************************************************************************************************************************************************
        - Fire paintballs from the gun when the Fire1 axis is used
        - When paintballs collide with a Paintable object they will change the color of the object and then
          destroy themselves*/
    [SerializeField] GameObject[] paintBalls;
    [SerializeField] GameObject spawn;
    GameObject currentObject;
    Mouse mouse;
    void Start()
    {
        mouse = Mouse.current;
    }
    void Update()
    {
        if(mouse != null)
        {
            if (mouse.leftButton.wasPressedThisFrame)
            {
                currentObject = Instantiate(paintBalls[0], spawn.transform);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Paintable"))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
            Destroy(currentObject);
        }
    }
}