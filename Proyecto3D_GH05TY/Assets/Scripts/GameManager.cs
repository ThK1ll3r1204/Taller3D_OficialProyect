using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    RoundCounterManager roundCounterScript;
    [Header ("Enemigos")]
    public int enemiesOnTheScene;
    public int enemiesMaxOnScene;
    public int enemiesPerSpawn;
    public int enemiesCanSpawn;
    public bool CanSpawn = true;

    [Header ("PowerUps")]
    public int currentPowerUps;


    void Start()
    {
        enemiesCanSpawn = enemiesPerSpawn;
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

        if (enemiesCanSpawn <= 0 && enemiesOnTheScene <= 0)
        {
            roundCounterScript.round++;
            roundCounterScript.RoundSucceeded();

        }        
    }
    
   
    
}


