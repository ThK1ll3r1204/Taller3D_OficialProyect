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
    public bool CanSpawn = true;
    
    [Header ("PowerUps")]
    public int currentPowerUps;

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

        
        if (enemiesOnTheScene >= enemiesMaxOnScene)
        {
            CanSpawn = false;
        }
        else
        {
            CanSpawn=true;
        }


    }
    
   
    
}


