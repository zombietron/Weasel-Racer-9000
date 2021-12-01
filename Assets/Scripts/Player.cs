using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    static int health = 3;

    public static int Health
    {
        set { health = value; }
        get { return health; }
    }
    // Start is called before the first frame update
    void Awake()
    {

    }



}
