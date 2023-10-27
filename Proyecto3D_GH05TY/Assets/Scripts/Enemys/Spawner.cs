using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;

    public float spawnInterval = 2.0f; 
    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0.0f;

            Instantiate(enemy1, transform.position, Quaternion.identity);
        }
    }
}
