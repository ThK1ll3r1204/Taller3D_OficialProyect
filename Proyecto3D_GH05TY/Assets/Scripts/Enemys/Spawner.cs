using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn; // Drag the prefab of the object to spawn here.
    public float spawnInterval = 2.0f; // Time between spawns.
    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0.0f;

            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
