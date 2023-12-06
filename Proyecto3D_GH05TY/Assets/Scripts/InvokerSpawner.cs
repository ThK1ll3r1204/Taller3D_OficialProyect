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
        }
        if (enemiesInInvok <= 0)
        {
            StopCoroutine(SpawnObjects());
        }
    }

    protected override IEnumerator SpawnObjects()
    {
        yield return base.SpawnObjects();
        enemiesInInvok--;
    }


}
