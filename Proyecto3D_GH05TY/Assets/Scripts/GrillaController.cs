using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class GrillaController : MonoBehaviour
{
    [SerializeField] GameObject terrainblock;
    [SerializeField] GameObject[] cubePrefab;
    [SerializeField] GameObject[] HazardBlockPrefab;
    [SerializeField] GameObject heartblock;
    [SerializeField] GameObject EnemyBlockPrefab;
    [SerializeField] GameObject PowerBlockPrefab;
    [SerializeField] NavMeshSurface walkableArea;
    
    public int gridSize = 10;
    public float delay = 0.5f;
    [SerializeField]
    int[][,] arrayGridMatrix;


    

    void Start()
    {
        
        int[,] matrix1 =
            {{0,0,5,0,0,0,0,1,1,0},
            {0,1,3,1,2,1,1,1,0,0},
            {1,1,0,1,2,0,0,1,0,4},
            {1,0,0,0,3,3,0,6,1,1},
            {1,0,0,3,1,1,3,2,1,0},
            {0,1,2,3,1,1,3,0,0,1},
            {1,1,6,0,3,3,0,0,0,1},
            {4,0,1,0,0,2,1,0,1,1},
            {0,0,1,1,1,2,1,3,1,0},
            {0,5,3,0,0,0,0,5,0,0}};



        int[,] matrix2 =
            {{5,3,0,1,3,3,1,0,3,5},
            {0,1,6,2,0,0,2,6,1,0},
            {0,1,0,2,0,0,2,0,1,0},
            {0,1,4,1,1,1,1,4,1,0},
            {0,1,0,1,1,1,1,0,1,0},
            {0,1,0,1,1,1,1,0,1,0},
            {0,1,4,1,1,1,1,4,1,0},
            {0,1,0,2,0,0,2,0,1,0},
            {0,1,6,2,0,0,2,6,1,0},
            {5,3,0,1,3,3,1,0,3,5}};



        int[,] matrix3 =
            {{5,1,0,0,0,0,0,1,0,0},
            {0,1,0,0,0,1,3,6,1,1},
            {0,1,2,2,2,2,0,0,0,1},
            {0,1,0,0,0,2,0,0,0,1},
            {0,3,1,1,1,1,1,1,0,1},
            {0,3,0,0,1,1,0,1,1,4},
            {5,1,0,0,1,0,0,1,0,0},
            {0,3,6,0,2,0,1,1,0,0},
            {0,0,1,2,2,2,1,0,0,0},
            {0,0,0,1,0,0,4,1,5,0}};



        int[,] matrix4 =
           {{4,1,1,1,5,5,1,1,1,4},
            {0,1,1,0,1,1,0,1,1,0},
            {0,0,0,0,1,1,0,0,0,0},
            {1,0,0,3,3,3,3,0,0,1},
            {6,2,2,3,1,1,3,2,2,3},
            {3,2,2,3,1,1,3,2,2,6},
            {1,0,0,3,3,3,3,0,0,1},
            {0,0,0,0,1,1,0,0,0,0},
            {0,1,1,1,1,1,1,1,1,0},
            {4,1,1,1,5,5,1,1,1,4}};



        int[,] matrix5 =
           {{5,1,1,1,0,1,6,1,1,0},
            {0,2,4,2,0,1,1,1,3,1},
            {0,1,0,2,0,1,3,0,1,0},
            {0,1,0,1,0,1,0,0,1,0},
            {0,1,3,1,1,1,1,1,1,0},
            {0,3,0,0,1,1,0,0,1,0},
            {0,1,0,0,1,0,0,0,3,0},
            {0,1,0,2,2,2,2,0,1,0},
            {1,1,2,4,0,0,2,2,6,0},
            {0,5,1,1,0,0,0,1,1,1}};



        int[,] matrix6 =
           {{5,0,0,1,0,0,0,0,0,0},
            {2,2,0,1,4,0,0,2,5,0},
            {1,2,0,1,0,0,0,2,1,0},
            {0,3,3,1,1,0,0,2,0,0},
            {0,0,0,1,1,1,1,3,1,2},
            {0,0,0,0,1,1,0,1,0,2},
            {0,0,2,0,0,1,0,0,0,6},
            {0,2,2,6,1,3,1,0,0,0},
            {0,5,2,0,0,1,4,0,0,0},
            {0,0,0,0,1,1,0,0,0,0}};



        int[,] matrix7 =
           {{0,1,1,1,1,1,1,1,1,0},
            {5,1,0,0,0,0,0,0,1,6},
            {1,3,2,2,1,1,2,2,3,1},
            {1,0,2,0,1,0,0,2,0,1},
            {4,0,1,3,1,1,0,1,0,1},
            {1,0,1,0,1,1,3,1,0,4},
            {1,0,2,0,1,0,0,2,0,1},
            {1,3,2,2,1,1,2,2,3,1},
            {6,1,0,0,0,0,0,0,1,5},
            {0,1,1,1,1,1,1,1,1,0}};



        int[,] matrix8 =
           {{1,5,1,1,1,0,0,0,0,0},
            {1,0,0,4,1,0,0,0,0,0},
            {0,0,0,0,1,1,0,0,0,6},
            {1,2,2,1,1,1,1,1,3,1},
            {6,3,0,0,1,1,1,0,0,0},
            {2,2,2,0,1,1,0,0,0,1},
            {1,1,2,1,1,1,1,1,3,1},
            {1,0,0,0,4,2,2,0,0,1},
            {0,0,0,0,0,2,0,0,5,1},
            {0,0,0,0,0,1,1,1,1,1}};



        int[,] matrix9 =
           {{0,0,0,2,4,0,0,1,5,1},
            {0,0,0,2,2,1,1,3,3,1},
            {0,0,0,1,2,1,1,3,0,1},
            {0,0,0,3,1,0,0,0,0,1},
            {6,2,2,1,1,1,1,0,0,1},
            {4,1,2,2,1,1,1,1,1,1},
            {0,0,0,1,1,1,1,0,0,0},
            {0,0,0,0,1,3,0,0,0,0},
            {1,1,3,1,1,1,1,3,1,1},
            {5,1,1,1,1,1,1,1,1,5}};




        int[,] matrix10 =
           {{0,0,0,0,1,1,5,1,0,0},
            {6,2,2,2,1,1,3,1,0,0},
            {1,2,2,0,0,0,4,0,0,0},
            {0,1,2,1,0,0,3,1,1,0},
            {0,3,0,1,1,1,0,1,1,1},
            {0,0,1,3,1,1,0,0,0,1},
            {1,1,1,3,2,2,1,2,0,1},
            {0,0,0,0,3,0,0,2,6,1},
            {0,0,0,0,4,1,0,1,1,1},
            {0,0,0,0,1,1,0,1,5,0}};



        int[,] matrix11 =
           {{1,1,1,0,0,0,1,1,1,1},
            {1,5,0,0,0,0,1,2,1,0},
            {0,4,2,0,0,0,0,1,2,0},
            {0,0,2,2,0,3,1,1,0,0},
            {0,0,0,1,1,1,0,3,2,0},
            {0,0,0,0,1,1,0,0,1,1},
            {0,0,0,1,2,1,0,1,2,2},
            {0,1,2,2,2,0,0,1,6,1},
            {1,5,3,0,0,0,4,3,1,0},
            {0,1,0,0,0,1,1,1,0,0}};



        int[,] matrix12 =
           {{0,2,1,3,1,3,1,0,0,5},
            {1,4,0,1,1,0,2,2,2,1},
            {0,1,0,0,0,0,0,1,1,1},
            {0,1,3,1,0,0,0,0,6,0},
            {0,0,0,3,1,1,0,1,2,0},
            {0,0,0,0,1,1,0,1,2,1},
            {0,1,1,0,0,0,0,0,1,1},
            {1,1,0,0,0,1,6,1,4,0},
            {0,5,2,2,0,1,3,1,1,0},
            {0,0,0,2,1,1,0,0,0,0}};



        int[,] matrix13 =
           {{5,1,0,0,1,0,0,1,1,1},
            {3,1,2,2,1,1,0,0,4,1},
            {0,1,0,0,6,0,0,0,1,0},
            {0,0,0,0,2,2,0,0,1,0},
            {0,1,0,3,1,1,3,1,1,1},
            {1,1,1,3,1,1,3,0,1,0},
            {0,2,0,0,1,2,0,0,0,0},
            {0,1,0,0,0,6,0,0,0,1},
            {0,4,1,0,1,2,1,2,3,1},
            {5,1,1,0,0,1,0,0,1,5}};



        int[,] matrix14 =
           {{0,0,0,0,1,0,0,1,1,5},
            {0,0,0,4,1,2,1,2,2,1},
            {0,3,2,1,0,0,3,6,0,0},
            {0,1,2,0,0,0,0,0,0,0},
            {0,3,1,1,1,1,1,3,0,0},
            {0,0,2,1,1,1,1,1,1,0},
            {1,2,0,0,0,0,0,0,2,1},
            {1,6,3,1,1,0,2,4,2,1},
            {0,1,1,2,1,2,1,0,0,0},
            {0,0,5,0,0,0,0,0,0,0}};



        int[,] matrix15 =
           {{5,1,1,0,1,2,1,6,0,0},
            {1,1,0,0,0,3,2,2,3,0},
            {4,0,0,0,3,1,2,2,1,1},
            {1,0,0,0,1,0,1,1,1,1},
            {1,2,0,0,1,1,0,1,3,1},
            {1,1,2,3,1,1,1,1,0,1},
            {0,0,2,2,2,0,0,0,0,4},
            {0,1,1,6,2,0,0,0,0,1},
            {0,1,1,0,1,3,0,0,1,1},
            {0,0,0,0,1,1,3,1,1,5}};


        arrayGridMatrix = new int[][,] { matrix1, matrix2, matrix3, matrix4, matrix5, matrix6, matrix7, matrix8, matrix9, matrix10, matrix11, matrix12, matrix13, matrix14, matrix15};
        int randomIndex = Random.Range(0, arrayGridMatrix.Length);
        StartCoroutine(SpawnCubes(arrayGridMatrix[randomIndex]));
        Debug.Log(randomIndex);
        

    }

    IEnumerator SpawnCubes(int[,] gridMatrix)
    {
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                int blockType = gridMatrix[y, x];
                Vector3 spawnPosition = new Vector3(x, 0, y) * 10;

                if (blockType == 1) 
                {
                    Instantiate(terrainblock, spawnPosition, Quaternion.identity);
                }
                else if (blockType == 2)
                {
                    Instantiate(HazardBlockPrefab[Random.Range(0, HazardBlockPrefab.Length)], spawnPosition, Quaternion.identity);
                }
                else if (blockType == 3)
                {
                    Instantiate(cubePrefab[Random.Range(0, cubePrefab.Length)], spawnPosition, Quaternion.identity);
                }
                else if (blockType == 4)
                {
                    Instantiate(heartblock, spawnPosition, Quaternion.identity);
                }
                else if (blockType == 5)
                {
                    Instantiate(EnemyBlockPrefab, spawnPosition, Quaternion.identity);
                }
                else if (blockType == 6)
                {
                    Instantiate(PowerBlockPrefab, spawnPosition, Quaternion.identity);
                }

                yield return new WaitForSeconds(delay);

            }
        }
        new WaitForSeconds(delay);        
        walkableArea.BuildNavMesh();

    }
}



