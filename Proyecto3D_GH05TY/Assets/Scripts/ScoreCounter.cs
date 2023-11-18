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
        scoreUI.text = "Score: " + Score;
        ScoreMultiplier();
    }

    public void AddScore(int value)
    {
        if (scoreMultiplierTimer > 3f)
        {
            Score += value * 2;
        }
        else if (scoreMultiplierTimer < 3)
        {
            Score += value;
        }
    }

    void ScoreMultiplier()
    {
        scoreMultiplierTimer -= Time.deltaTime;
        if (scoreMultiplierTimer <= 0f)
        {
            scoreMultiplierTimer = 0f;
        }

    }
}
