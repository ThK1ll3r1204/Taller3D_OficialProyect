using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static int Score;
    [SerializeField]
    private Text scoreUI;
    [SerializeField]
    private Text scoreMultiplierUI;
    public float scoreMultiplierTimer;
    RoundCounterManager roundManager;
    
    void Start()
    {
        roundManager = GameObject.Find("RoundManager").GetComponent<RoundCounterManager>();

        if (roundManager.round == 1)
        {
            Score = 0;
        }
        
        scoreMultiplierTimer = 0;
        
    }

    void Update()
    {
        if ((scoreUI == null))
        {
            scoreUI = GameObject.Find("Score").GetComponent<Text>();
            scoreMultiplierUI = GameObject.Find("ScoreMultiplier").GetComponent<Text>();
        }
        scoreUI.text = "Score: " + Score;
        scoreMultiplierUI.text = "x" + ((Mathf.FloorToInt(scoreMultiplierTimer) / 3) + 1);
        ScoreMultiplier();
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
