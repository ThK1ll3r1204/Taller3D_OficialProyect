using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundCounterManager : MonoBehaviour
{
    public int round;
    GameManager gameManagerScript;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        gameManagerScript = FindAnyObjectByType<GameManager>();
        round = 1;
    }

    public void RoundSucceeded()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        round++;
    }
}
