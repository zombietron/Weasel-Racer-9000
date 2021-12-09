using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Collectible", menuName ="Collectible", order=0)]
public class SpawnableItem : ScriptableObject
{
    public GameObject Collectible;

    public int pointValue;


}
