using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneOnClick : MonoBehaviour
{   
    public void LoadSelectedScene(int num)
    {
        SceneManager.LoadScene(num);
    }
}
