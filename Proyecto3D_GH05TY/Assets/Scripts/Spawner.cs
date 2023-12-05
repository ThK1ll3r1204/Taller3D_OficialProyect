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
    public int maxObjectsOnScreen;
    public int SpawnedObjectsCounter;
    public int maxSpawnedObjects;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }
    
    protected virtual IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            if (GameManager.gameManager.enemiesCanSpawn >=0 && GameManager.gameManager.CanSpawn)
            {
                int randomIndex = Random.Range(0, gameObjectsPrefabs.Length);
                GameObject randomPrefab = gameObjectsPrefabs[randomIndex];
                Instantiate(randomPrefab, transform.position, Quaternion.identity);
                GameManager.gameManager.enemiesCanSpawn--;

            }
            
        }

    }
    

}
