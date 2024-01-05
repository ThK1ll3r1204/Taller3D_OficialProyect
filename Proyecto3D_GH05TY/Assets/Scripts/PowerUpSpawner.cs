using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : Spawner
{
    GameManager gameManager;
    void Start()
    {
        gameManager= FindAnyObjectByType<GameManager>();
        StartCoroutine(SpawnObjects());
    }

    protected override IEnumerator SpawnObjects()
    {
        while (gameManager.CanSpawnPowerUps==true)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, gameObjectsPrefabs.Length);
            GameObject randomPrefab = gameObjectsPrefabs[randomIndex];
            Instantiate(randomPrefab, transform.position, Quaternion.identity);
        }
    }
}
