using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokerSpawner : Spawner
{
    Enemy3Move enemy3Script;
    public int enemiesInInvok;
    
    void Start()
    {
        StartCoroutine(SpawnObjects());
        enemy3Script = GetComponentInParent<Enemy3Move>();
    }

    void Update()
    {
        if (enemiesInInvok<=0)
        {
            enemy3Script.enableLastBehaviour = true;
            //StopCoroutine(SpawnObjects());
        }        
    }

    protected override IEnumerator SpawnObjects()
    {
        while(enemiesInInvok > 0)
        {
            yield return new WaitForSeconds(spawnRate);

            int randomIndex = Random.Range(0, gameObjectsPrefabs.Length);
            GameObject randomPrefab = gameObjectsPrefabs[randomIndex];
            Instantiate(randomPrefab, transform.position, Quaternion.identity);
            enemiesInInvok--;
        }
    }
}



