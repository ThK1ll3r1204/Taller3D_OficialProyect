using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundCounterManager : MonoBehaviour
{
    public int round;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        round = 1;
    }

    public void RoundSucceeded()
    {
        if (round % 3 == 0)
        {
            GameManager.gameManager.enemiesPerSpawn += 2;
            GameManager.gameManager.enemiesMaxOnScene += 4;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
