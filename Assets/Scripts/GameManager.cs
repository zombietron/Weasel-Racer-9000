using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //an array that stores car models for opening screen selection.
    [SerializeField] GameObject[] carOptions;
    
    //the index of the selected car, defaulting at 0 (first car). 
    [SerializeField] int carSelection;

    public int CarChoice
    {
        set { carSelection = value; }
        get { return carSelection;  }
    }
    
    //the transform of the 'player' object to instantiate our car mesh as a child of
    Transform player;

    //The current HighScore that will be serialized
    int highScore;
    public int HighScore
    {
        set { highScore = value; }
        get { return highScore; }
    }


    // Start is called before the first frame update
    void Awake()
    {
        
        DontDestroyOnLoad(this);
        if (manager == null)
        {
            manager = this;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

        
    }

    
    public void SpawnVehicle(int num)
    {
        Instantiate<GameObject>(carOptions[carSelection], player);
    }

    public void OnSceneLoaded(Scene s, LoadSceneMode m)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            Debug.Log("OnSceneLoadedCalled");
            SpawnVehicle(carSelection);
            UIManager.Instance.UpdateScore(currentScore);
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }

    public void GameOver()
    {
        CheckHighScore();
        //save some data
        //create a save data object
    }

    public void CheckHighScore()
    {
        if(currentScore > highScore)
        {
            highScore = currentScore;
        }
    }
}
