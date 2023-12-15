using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [Header ("Enemigos")]
    public int enemiesOnTheScene;
    public int enemiesMaxOnScene;
    public int enemiesCanSpawn;
    public bool CanSpawnEnemies = true;
    
    [Header ("PowerUps")]
    public int powerUpsOnTheScene;
    public int powerUpsMaxOnTheScene;
    public bool CanSpawnPowerUps = true;

    private void Awake()
    {
        if (GameManager.gameManager == null && SceneManager.GetActiveScene().name == "Cesar")
        {
            GameManager.gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        enemiesOnTheScene = GameObject.FindGameObjectsWithTag("Enemy").Length;
        powerUpsOnTheScene = GameObject.FindGameObjectsWithTag("PowerUp").Length;

        
        if (enemiesOnTheScene >= enemiesMaxOnScene)
        {
            CanSpawnEnemies = false;
        }
        else if (enemiesOnTheScene < enemiesMaxOnScene)
        {
            CanSpawnEnemies = true;
        }
        
        if (powerUpsOnTheScene >= powerUpsMaxOnTheScene)
        {
            CanSpawnPowerUps = false;
        }
        else
        {
            CanSpawnPowerUps = true;
        }


    }
}


