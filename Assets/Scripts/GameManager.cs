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
        set
        {
            currentScore = value;
            UIManager.Instance.UpdateScore(currentScore);
        }
        get { return currentScore; }
    }

    //an array that stores car models for opening screen selection.
    [SerializeField] GameObject[] carOptions;

    //the index of the selected car, defaulting at 0 (first car). 
    [SerializeField] int carSelection;

    public int CarChoice
    {
        set { carSelection = value; }
        get { return carSelection; }
    }

    public delegate void OnLevelStart();

    public OnLevelStart levelStart;

    bool isRunning;
    public bool running
    {
        private set{}
        get { return isRunning; }
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
        if (manager != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);

        manager = this;

       SceneManager.sceneLoaded += OnSceneLoaded;

        
    }

    private void Update()
    {
        if(Player.Health <=0 && isRunning)
        {
            GameOver();
        }
    }
    private void Start()
    {
        
        SaveData.LoadGameData();
    }


    public void SpawnVehicle(int num)
    {
        Instantiate<GameObject>(carOptions[carSelection], player);
    }

    public void OnSceneLoaded(Scene s, LoadSceneMode m)
    {
        isRunning = true;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            Debug.Log("OnSceneLoadedCalled");
            SpawnVehicle(carSelection);
            currentScore = 0;
            UIManager.Instance.UpdateScore(currentScore);
            levelStart.Invoke();
        }
    }

    public void GameOver()
    {
        isRunning = false;
        UIManager.Instance.DisplayGameOver();
        Player.Health = 3;
        CheckHighScore();
        SaveData.SaveGameData();
        Debug.Log("Game over man!");

    }

    public void CheckHighScore()
    {
        if(currentScore > highScore)
        {
            highScore = currentScore;
        }
    }

    public void RestartGame()
    {
        
        StartCoroutine(restart(.5f));    
    }

    public IEnumerator restart(float t)
    {
        SpawnController.Instance.StopAllCoroutines();
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(0);
        yield break;
    }

}
