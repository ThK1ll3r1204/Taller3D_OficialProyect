using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : Spawner
{
    void Start()
    {
        gameManager= FindAnyObjectByType<GameManager>();
        StartCoroutine(SpawnObjects());
    }

    protected override IEnumerator SpawnObjects()
    {
        Debug.Log(new WaitForSeconds(spawnRate));
        while (gameManager.powerUpsMaxOnTheScene < gameManager.powerUpsOnTheScene && gameManager.CanSpawnPowerUps)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, gameObjectsPrefabs.Length);
            GameObject randomPrefab = gameObjectsPrefabs[randomIndex];
            Instantiate(randomPrefab, transform.position, Quaternion.identity);
        }

    }
}
