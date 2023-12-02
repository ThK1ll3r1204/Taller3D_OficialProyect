using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GrillaController grillaController;
    public static GameManager gameManager;
    Spawner spawner;
    RoundCounterManager roundCounterScript;
    public int currentEnemies;
    public int currentPowerUps;
    public int enemiesOnTheScene;

    void Start()
    {
        grillaController = FindAnyObjectByType<GrillaController>();
        spawner = FindAnyObjectByType<Spawner>();
        roundCounterScript = FindAnyObjectByType<RoundCounterManager>();
    }

    private void Update()
    {
        
        if (spawner.SpawnedObjectsCounter >= spawner.maxSpawnedObjects && currentEnemies <= 0 && grillaController.gridFinish==true)
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


