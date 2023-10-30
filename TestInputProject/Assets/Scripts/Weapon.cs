using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Weapon", menuName="Scriptable Objects/Weapon")]
public class Weapon : ScriptableObject
{
    //public int weaponIndex;
    public string weaponText;
    public GameObject weaponModel;
}