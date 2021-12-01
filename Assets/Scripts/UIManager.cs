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
    [SerializeField] TMP_Text gameOverText;
    // Start is called before the first frame update
    void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else { instance = this; }

        SetHighScore(GameManager.Manager.HighScore);
        gameOverText.gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreValue.text = score.ToString();
    }

    public void SetHighScore(int score)
    {
        highScore.text = score.ToString();
    }

    public IEnumerator ScaleTextOverTime(float t, float scale)
    {
        Debug.Log("Scaling started");
        float timer = 0.0f;
       
        while (timer <= t)
        {
            timer += Time.deltaTime / t;
            float newS = Mathf.Lerp(1.0f, scale, timer);
            gameOverText.transform.localScale = new Vector3(newS, newS, transform.localScale.z);
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("Finishing CoRoutine");
        gameOverText.gameObject.SetActive(false);
        GameManager.Manager.RestartGame();

        yield break;


    }

    public void DisplayGameOver()
    {
        
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            StartCoroutine(ScaleTextOverTime(2, 2));
        }
        else { Debug.LogWarning("Null Check Failed: UIManager.DisplayGameOver()"); }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }



}
