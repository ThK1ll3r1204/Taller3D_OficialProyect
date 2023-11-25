using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundCounterManager : MonoBehaviour
{
    public int enemyKilled;
    public int enemiesToKill;
    public int round;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        round = 1;
        enemiesToKill = 10;
    }

    void Update()
    {
        if (enemyKilled >= enemiesToKill)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            round++;
            enemyKilled = 0;
            enemiesToKill += 2;
        }
        else
        {
            return;
        }
        for (round = 1; round <= 1; round++)
        {
            if (round % 2 == 0)
            {
                enemiesToKill += 2;

            }
        }
    }
}
