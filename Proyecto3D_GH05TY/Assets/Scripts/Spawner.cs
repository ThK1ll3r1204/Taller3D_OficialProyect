using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] gameObjectsPrefabs;
    public GameObject[] mediumSpawner;
    public GameObject[] hardSpawner;
    [SerializeField]  protected float spawnRate;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameManager.gameManager;
        StartCoroutine(SpawnObjects());
    }
    
    protected virtual IEnumerator SpawnObjects()
    {
        GameObject[] spawnerPrefabs;

        if (RoundCounterManager.Instance.round < 3)
        {
            spawnerPrefabs = gameObjectsPrefabs;
        }
        else if (RoundCounterManager.Instance.round < 5)
        {
            spawnerPrefabs = mediumSpawner;
        }
        else
        {
            spawnerPrefabs = hardSpawner;
        }

        while (gameManager.enemiesCanSpawn > 0 && gameManager.CanSpawnEnemies)
        {
            yield return new WaitForSeconds(spawnRate);
            
            int randomIndex = Random.Range(0, spawnerPrefabs.Length);
            GameObject randomPrefab = spawnerPrefabs[randomIndex];
            Instantiate(randomPrefab, transform.position, Quaternion.identity);
            gameManager.enemiesCanSpawn--;                       
        }
    }    
}
