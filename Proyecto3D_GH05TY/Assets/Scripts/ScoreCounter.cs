using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int Score;
    [SerializeField]
    private Text scoreUI;
    public float scoreMultiplierTimer;
    void Start()
    {
        Score = 0;
        scoreMultiplierTimer = 0;
    }

    void Update()
    {
        scoreUI.text = "Score: " + Score + " | x" + ((Mathf.FloorToInt(scoreMultiplierTimer) / 3) + 1);
        ScoreMultiplier();
    }

    public void AddScore(int value)
    {
        Score += value * ( ((Mathf.FloorToInt(scoreMultiplierTimer) / 3) + 1) >= 5 ? 5: ((Mathf.FloorToInt(scoreMultiplierTimer) / 3) + 1)); 
        //if (scoreMultiplierTimer > 3f)
        //{
        //    Score += value * 2;
        //}
        //else if (scoreMultiplierTimer < 3)
        //{
        //    Score += value;
        //}
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
