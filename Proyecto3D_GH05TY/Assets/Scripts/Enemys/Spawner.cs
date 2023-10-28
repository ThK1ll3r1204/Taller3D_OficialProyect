using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] gameObjectsPrefabs;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    string spawnObjectsTag;
    [SerializeField]
    int maxObjectsOnScreen;
    private int totalSpawnedObjects;
    public int maxSpawnedObjects;
    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            int currentEntities = CountObjectsWithTag(spawnObjectsTag);

            if (currentEntities < maxObjectsOnScreen || totalSpawnedObjects < maxSpawnedObjects)
            {
                int randomIndex = Random.Range(0, gameObjectsPrefabs.Length);
                GameObject randomPrefab = gameObjectsPrefabs[randomIndex];
                Instantiate(randomPrefab, transform.position, Quaternion.identity);
                totalSpawnedObjects++;
            }
        }

    }
    int CountObjectsWithTag(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        return objectsWithTag.Length;
    }

}
