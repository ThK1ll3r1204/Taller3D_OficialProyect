using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : Spawner
{
    void Start()
    {
        StartCoroutine(SpawnObjects());
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    protected override IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            if (gameManager.currentEnemies < maxObjectsOnScreen || totalSpawnedObjects < maxSpawnedObjects)
            {
                int randomIndex = Random.Range(0, gameObjectsPrefabs.Length);
                GameObject randomPrefab = gameObjectsPrefabs[randomIndex];
                Instantiate(randomPrefab, transform.position, Quaternion.identity);
                this.totalSpawnedObjects++;
                gameManager.currentPowerUps++;
            }
        }

    }
}
