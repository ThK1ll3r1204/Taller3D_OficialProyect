using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class GridScript : MonoBehaviour
{

    [SerializeField] GameObject[] cubePrefab;
    [SerializeField] GameObject iceBlockPrefab;
    [SerializeField] GameObject[] MudBlockPrefab;
    [SerializeField] GameObject emptyBlockPrefab;
    public int gridSize = 10;
    public float delay = 0.5f;

    public bool BobElConstructor = true;

    [SerializeField]
    int[][,] arrayGridMatrix;

    [SerializeField] int[] g;

    [SerializeField] int randomIndex;

    int[,] grid1 = {  { 1, 4 },
                      { 1, 1 } };

    int[,] grid2 = { { 4, 1 },
                     { 1, 1 } };

    int[,] grid3 = { { 1, 1 },
                     { 1, 4 } };

    int[,] grid4 = { { 1, 2 },
                     { 1, 1 } };

    int[,] grid5 = { { 1, 2 },
                     { 1, 0} };

    int[,] grid6 = { { 1, 0 },
                     { 1, 1 } };

    int[,] grid7 = { { 3, 1 },
                     { 1, 1 } };

    int[,] grid8 = { { 2, 1 },
                     { 1, 1 } };

    int[,] grid9 = { { 1, 1 },
                     { 1, 1 } };
    
    int[,] grid10 = { { 1, 1 },
                     { 1, 1 } };
    
    int[,] grid11 = { { 1, 1 },
                     { 1, 4 } };

    void Start()
    {
        arrayGridMatrix = new int[][,] { grid1, grid2, grid3, grid4, grid5, grid6, grid7, grid8, grid9, grid10, grid11 };
        BobElConstructor = true;
    }

    private void Update()
    {
        randomIndex = Random.Range(0, arrayGridMatrix.Length);
        if (BobElConstructor)
        {
            StartCoroutine(SpawnCubes());
            BobElConstructor = false;
        }
        else
        {
            Debug.Log("NoEstaElConchaDeSuMadreDeBob");
        }
    }
    

    IEnumerator SpawnCubes()
    {
        for (int y = 0; y < gridSize; y += 2)
        {
            for (int x = 0; x < gridSize; x += 2)
            {
                int[,] gridMatrix = arrayGridMatrix[randomIndex];
                for (int i = 0; i < 2; i++)
                {

                    for (int j = 0; j < 2; j++)
                    {

                        int blockType = gridMatrix[i, j];
                        Vector3 spawnPosition = new Vector3(x + j, 0, y + i) * 10;

                        if (blockType == 1)
                        {
                            Instantiate(cubePrefab[Random.Range(0, cubePrefab.Length)], spawnPosition, Quaternion.identity);

                        }
                        else if (blockType == 2)
                        {
                            Instantiate(iceBlockPrefab, spawnPosition, Quaternion.identity);

                        }
                        else if (blockType == 3)
                        {
                            Instantiate(emptyBlockPrefab, spawnPosition, Quaternion.identity);

                        }
                        else if (blockType == 4)
                        {
                            Instantiate(MudBlockPrefab[Random.Range(0, MudBlockPrefab.Length)], spawnPosition, Quaternion.identity);

                        }
                        else
                        {
                            Instantiate(cubePrefab[Random.Range(0, cubePrefab.Length)], spawnPosition, Quaternion.identity);                  

                        }

                        yield return new WaitForSeconds(delay);
                    }
                }
            }
        }
    }
}
