using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]  GameObject[] gameObjectsPrefabs;
    [SerializeField]  protected float spawnRate;
    public GameManager gameManager;
    

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        StartCoroutine(SpawnObjects());
    }
    
    protected virtual IEnumerator SpawnObjects()
    {
        while (gameManager.enemiesCanSpawn > 0 && gameManager.CanSpawn)
        {
            yield return new WaitForSeconds(spawnRate);

            int randomIndex = Random.Range(0, gameObjectsPrefabs.Length);
            GameObject randomPrefab = gameObjectsPrefabs[randomIndex];
            Instantiate(randomPrefab, transform.position, Quaternion.identity);
            gameManager.enemiesCanSpawn--;
                      
        }
    }    
}
