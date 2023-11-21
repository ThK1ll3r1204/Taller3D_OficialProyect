using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int Score;
    [SerializeField]
    private Text scoreUI;
    public float scoreMultiplierTimer;
    public int enemyKilled;
    public int enemiesToKill;
    public int round;
    [SerializeField] static ScoreCounter scoreCounter;

    void Awake()
    {
        if (ScoreCounter.scoreCounter == null)
        {
            round = 1;
            scoreCounter = this;
            enemiesToKill = 10;
            DontDestroyOnLoad(gameObject);
            scoreCounter=GetComponent<ScoreCounter>(); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Score = 0;
        scoreMultiplierTimer = 0;
        scoreUI= GameObject.Find("Score").GetComponent<Text>();
        if ((scoreUI == null))
        {
            return;
        }
    }

    void Update()
    {
        
        
        scoreUI = GameObject.Find("Score").GetComponent<Text>();
        scoreUI.text = "Score: " + Score + " | x" + ((Mathf.FloorToInt(scoreMultiplierTimer) / 3) + 1);
        ScoreMultiplier();

        if (enemyKilled >= enemiesToKill)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            round ++;
            enemyKilled = 0;
            enemiesToKill += 2;
        }
        else
        {
            return;
        }
        for (round = 1; round <= 1; round++)
        {
            // Verificar si round es un múltiplo de 3
            if (round % 2 == 0)
            {
                // Aumentar enemiesToKill en 2
                enemiesToKill += 2;

                // Puedes agregar aquí cualquier otra lógica que desees ejecutar cuando round sea un múltiplo de 3.
            }
        }

    }

    public void AddScore(int value)
    {
        Score += value * ( ((Mathf.FloorToInt(scoreMultiplierTimer) / 3) + 1) >= 5 ? 5: ((Mathf.FloorToInt(scoreMultiplierTimer) / 3) + 1)); 
        
    }

    void ScoreMultiplier()
    {
        scoreMultiplierTimer -= Time.deltaTime;
        if (scoreMultiplierTimer <= 0f)
        {
            scoreMultiplierTimer = 0f;
        }
    }

    public void SaveHighScore()
    {
        int OldScore = PlayerPrefs.GetInt("highScore", 0);

        if (OldScore < Score)
        {
            PlayerPrefs.SetInt("highScore", Score);
        }
    }
}
