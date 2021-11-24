using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int pointValue;

    private void OnDestroy()
    {
        GameManager.Manager.CurrentScore += pointValue;
    }


}
