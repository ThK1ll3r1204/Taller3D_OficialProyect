using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokerSpawner : Spawner
{
    Enemy3Move enemy3Script;
    void Start()
    {
        StartCoroutine(SpawnObjects());
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemy3Script = GetComponentInParent<Enemy3Move>();
    }

    void Update()
    {
        if (this.SpawnedObjectsCounter <= this.maxSpawnedObjects)
        {
            enemy3Script.enableLastBehaviour = true;
        }
    }

    protected override IEnumerator SpawnObjects()
    {
        yield return base.SpawnObjects();

    }


}
