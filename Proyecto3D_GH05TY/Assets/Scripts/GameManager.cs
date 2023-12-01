using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    Spawner spawner;
    RoundCounterManager roundCounterScript;
    public int currentEnemies;
    public int currentPowerUps;
    public int enemiesOnTheScene;

    void Start()
    {
        spawner = FindAnyObjectByType<Spawner>();
        roundCounterScript = FindAnyObjectByType<RoundCounterManager>();
    }

    private void Update()
    {
        if (spawner.SpawnedObjectsCounter >= spawner.maxSpawnedObjects || currentEnemies == 0)
        {
            SecondCheckForEnemies();

        }
    }

    public void SecondCheckForEnemies()
    {
        enemiesOnTheScene = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemiesOnTheScene <= 0)
        {
            roundCounterScript.RoundSucceeded();
        }
    }
    
}


