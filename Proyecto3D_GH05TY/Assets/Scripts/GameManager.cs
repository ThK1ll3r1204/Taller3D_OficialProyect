using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentEnemies;
    public int currentPowerUps;
    void Start()
    {
        
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Rafael_Escena");
        }
    }
}
