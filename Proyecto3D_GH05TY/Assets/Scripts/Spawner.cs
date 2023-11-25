using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] gameObjectsPrefabs;
    [SerializeField]
    protected float spawnRate;
    [SerializeField]
    protected int maxObjectsOnScreen;
    [SerializeField] protected int totalSpawnedObjects;
    public int maxSpawnedObjects;
    protected GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnObjects());
    }
    
    protected virtual IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            if (gameManager.currentEnemies < maxObjectsOnScreen || totalSpawnedObjects <= maxSpawnedObjects && gameManager.CanSpawn==true)
            {
                int randomIndex = Random.Range(0, gameObjectsPrefabs.Length);
                GameObject randomPrefab = gameObjectsPrefabs[randomIndex];
                Instantiate(randomPrefab, transform.position, Quaternion.identity);
                totalSpawnedObjects++;
                gameManager.currentEnemies++;
            }
            
        }

    }
    

}
