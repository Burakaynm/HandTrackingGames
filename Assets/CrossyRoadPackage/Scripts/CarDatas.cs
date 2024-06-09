using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Car Data", menuName = "Car Data")]
public class CarDatas : ScriptableObject
{
    public GameObject car;
    public int maxInSuccession;
}
