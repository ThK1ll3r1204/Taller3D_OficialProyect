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
        scoreUI= GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        scoreUI.text = "Score: " + Score + " | x" + ((Mathf.FloorToInt(scoreMultiplierTimer) / 3) + 1);
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
