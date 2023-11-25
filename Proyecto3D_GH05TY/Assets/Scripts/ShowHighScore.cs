using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour
{
    [SerializeField]
    Text highScoreUI;
    
    void Start()
    {
        highScoreUI.text = "" + PlayerPrefs.GetInt("highScore", 0);
    }
}
