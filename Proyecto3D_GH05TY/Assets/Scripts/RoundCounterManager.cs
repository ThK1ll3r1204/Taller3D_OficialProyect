using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundCounterManager : MonoBehaviour
{
    public static RoundCounterManager Instance;
    public int round;
    public GameManager gameManager;
    private int initialAmmo;
    private int maxEnemies;

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
        round = 1;
        gameManager = FindAnyObjectByType<GameManager>();
        initialAmmo = gameManager.enemiesCanSpawn;
        maxEnemies = gameManager.enemiesMaxOnScene;
    }

    private void Update()
    {
        if (gameManager.enemiesCanSpawn <= 0 && gameManager.enemiesOnTheScene <= 0)
        {
            
            RoundSucceeded();
        }
        
    }

    

    public void RoundSucceeded()
    {
        round++;
        if (round % 3 == 0)
        {
            Debug.Log("DEBE SUMAR EN GAMEMANAGER");
            gameManager.enemiesCanSpawn = initialAmmo + 2;
            gameManager.enemiesMaxOnScene = maxEnemies + 4;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
