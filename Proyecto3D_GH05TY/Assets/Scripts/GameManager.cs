using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GrillaController grillaController;
    public static GameManager gameManager;
    RoundCounterManager roundCounterScript;
    public int currentEnemies;
    public int currentPowerUps;
    public int enemiesOnTheScene;
    public int enemiesMaxOnScene;
    public int enemiesPerSpawn;
    public int enemiesCanSpawn;
    public bool CanSpawn;

    void Start()
    {
        enemiesPerSpawn = enemiesCanSpawn;
        grillaController = FindAnyObjectByType<GrillaController>();
        roundCounterScript = FindAnyObjectByType<RoundCounterManager>();
    }

    private void Update()
    {
        enemiesOnTheScene = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemiesOnTheScene >= enemiesMaxOnScene)
        {
            CanSpawn = false;
        }
        else
        {
            CanSpawn = true;
        }

        if (enemiesCanSpawn >= enemiesPerSpawn && enemiesOnTheScene <= 0 )
        {
            //roundCounterScript.RoundSucceeded();

        }        
    }
    
   
    
}


