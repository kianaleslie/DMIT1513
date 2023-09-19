using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemSwitcher : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    [SerializeField] GameObject spawn;
    GameObject currentObject;
    Keyboard kb;

    void Start()
    {
        kb = Keyboard.current;
    }
    void Update()
    {
        if (kb != null)
        {
            if (kb.digit1Key.wasPressedThisFrame)
            {
                Destroy(currentObject);
                currentObject = Instantiate(items[0], spawn.transform);
            }
            if (kb.digit2Key.wasPressedThisFrame)
            {
                Destroy(currentObject);
                currentObject = Instantiate(items[1], spawn.transform);
            }
        }
    }
}