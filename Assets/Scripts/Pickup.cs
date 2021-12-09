using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public SpawnableItem collectible;

    int pointValue;

    public void Start()
    {
        pointValue = collectible.pointValue;
    }
    private void OnDestroy()
    {
        GameManager.Manager.CurrentScore += pointValue;
    }


}
