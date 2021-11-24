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
    [SerializeField] TMP_Text highScore;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        SetHighScore(GameManager.Manager.HighScore);
    }

    public void UpdateScore(int score)
    {
        scoreValue.text = score.ToString();
    }

    public void SetHighScore(int score)
    {
        highScore.text = score.ToString();
    }

}
