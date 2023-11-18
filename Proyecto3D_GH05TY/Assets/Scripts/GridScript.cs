using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class GridScript : MonoBehaviour
{

    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject iceBlockPrefab;
    [SerializeField] GameObject MudBlockPrefab;
    [SerializeField] GameObject emptyBlockPrefab;
    public int gridSize = 10;
    public float delay = 0.5f;

    public bool BobElConstructor = true;

    [SerializeField]
    int[,] grid = new int[10, 10];
    int[,] grid2 = new int[2, 2];
    [SerializeField]
    int[][,] arrayGridMatrix;

    [SerializeField]
    bool[] CanBuildThisBlock;

    [SerializeField] int[] g;
    
    [SerializeField] int h;
    [SerializeField] int j;

    void Start()
    {
        
        BobElConstructor = true;
    }

    private void Update()
    {
        h = Random.Range(1, g.Length + 1);
        j = Random.Range(1, g.Length + 1);


        int[,] gridx2 = { { j, j }, { j, j } };

        int[,] grid ={
        { h,h,h,h,h,h,h,h,h,h},
        { h,h,h,h,h,h,h,h,h,h},
        { h,h,h,h,h,h,h,h,h,h},
        { h,h,h,h,h,h,h,h,h,h},
        { h,h,h,h,h,h,h,h,h,h},
        { h,h,h,h,h,h,h,h,h,h},
        { h,h,h,h,h,h,h,h,h,h},
        { h,h,h,h,h,h,h,h,h,h},
        { h,h,h,h,h,h,h,h,h,h},
        { h,h,h,h,h,h,h,h,h,h}};


        arrayGridMatrix = new int[][,] { grid, gridx2 };

        if (BobElConstructor)
        {
            StartCoroutine(SpawnCubes(grid));
            BobElConstructor = false;
        }
        else
        {
            Debug.Log("NoEstaElConchaDeSuMadreDeBob");
        }

    }

    IEnumerator SpawnCubes(int[,] gridMatrix)
    {
        yield return new WaitForSeconds(1);
    }
}
