using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundCounterManager : MonoBehaviour
{
    public static RoundCounterManager Instance;
    public int round;
    GameManager gameManager;
    private void Awake()
    {

        if (RoundCounterManager.Instance == null && SceneManager.GetActiveScene().name == "Cesar")
        {
            RoundCounterManager.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);    
        }

    }

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        round = 1;
    }

    public void RoundSucceeded()
    {
        if (round % 3 == 0)
        {

            gameManager.enemiesPerSpawn += 2;
            gameManager.enemiesMaxOnScene += 4;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
