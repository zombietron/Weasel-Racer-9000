using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager manager;
    public static GameManager Manager
    {
        get { return manager; }
    }

    [SerializeField] int currentScore;
    
    public int CurrentScore
    {
        set { currentScore = value; }
        get { return currentScore; }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (manager == null)
        {
            manager = this;
        }

        UIManager.Instance.UpdateScore(currentScore);
    }

}
