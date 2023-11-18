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
    protected int totalSpawnedObjects;
    public int maxSpawnedObjects;
    protected GameManager gameManager;
    private void Start()
    {
        StartCoroutine(SpawnObjects());
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    protected virtual IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            if (gameManager.currentEnemies < maxObjectsOnScreen || totalSpawnedObjects < maxSpawnedObjects)
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
