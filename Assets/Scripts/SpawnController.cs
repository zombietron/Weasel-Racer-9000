using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    int index = 0;
    int spawnLoc = 0;

    public float spawnGap;

    public GameObject[] spawnables;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.Manager.levelStart += StartSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnEnemies());
    }

    public GameObject GetEnemyToSpawn()
    {
        index++;

        if (index > spawnables.Length-1)
        {
            index = 0;
        }
       
        return spawnables[index];
    }

    public Transform GetSpawnLocation()
    {
        if(spawnLoc > spawnPoints.Length-1)
        {
            spawnLoc = 0;
        }
        Transform t = spawnPoints[spawnLoc];
        spawnLoc++;
        return t;
    }

    public IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnGap);
            GameObject go = Instantiate<GameObject>(GetEnemyToSpawn());
            go.transform.position = GetSpawnLocation().position;

        }
    }
}
