using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] gameObjectsPrefabs;
    [SerializeField]  protected float spawnRate;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameManager.gameManager;
        StartCoroutine(SpawnObjects());
    }
    
    protected virtual IEnumerator SpawnObjects()
    {
        while (gameManager.enemiesCanSpawn > 0 && gameManager.CanSpawnEnemies)
        {
            yield return new WaitForSeconds(spawnRate);

            int randomIndex = Random.Range(0, gameObjectsPrefabs.Length);
            GameObject randomPrefab = gameObjectsPrefabs[randomIndex];
            Instantiate(randomPrefab, transform.position, Quaternion.identity);
            gameManager.enemiesCanSpawn--;                       
        }
    }    
}
