using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    
    public static UIManager Instance
    {
        get { return instance; }
    }

    [SerializeField] TMP_Text scoreValue;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdateScore(int score)
    {
        scoreValue.text = score.ToString();
    }


}
