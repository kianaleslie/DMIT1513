using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonRecoil : MonoBehaviour
{
    Keyboard kb;
    public Vector3 recoil;
    Vector3 noRecoil;

    private void Start()
    {
        kb = Keyboard.current;
        noRecoil = transform.localEulerAngles;
    }
    private void Update()
    {
        if (kb.spaceKey.wasPressedThisFrame)
        {
            Recoil();
        }
        else
            if (kb.spaceKey.wasReleasedThisFrame)
        {
            NoRecoil();
        }
    }
    private void Recoil()
    {
        transform.localEulerAngles += recoil;
    }
    private void NoRecoil()
    {
        transform.localEulerAngles = noRecoil;
    }
}
//refernce: https://www.youtube.com/watch?v=zG0RFt1BlfU