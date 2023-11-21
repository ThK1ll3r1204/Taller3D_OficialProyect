using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    PowerUpSpawner powerUpSpawner;
    Spawner spawner;
    public bool CanSpawn;
    public bool CanSpawnPowerUps;
    public int currentEnemies;
    public int currentPowerUps;
    public int enemies;
    public int powerUps;


    

    void Start()
    {
        currentEnemies = 0;
        currentPowerUps = 0;
        spawner = FindAnyObjectByType<Spawner>();
        powerUpSpawner= FindAnyObjectByType<PowerUpSpawner>();
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        powerUps = GameObject.FindGameObjectsWithTag("PowerUp").Length;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Rafael_Escena");
        }
        
        if(powerUps>= 2)
        {
            CanSpawnPowerUps = false;
        }
        else
        {
            CanSpawnPowerUps= true;
        }

        if(enemies>=10f)
        {
            CanSpawn = false;
        }
        else
        {
            CanSpawn= true;
        }

    }
    
}


