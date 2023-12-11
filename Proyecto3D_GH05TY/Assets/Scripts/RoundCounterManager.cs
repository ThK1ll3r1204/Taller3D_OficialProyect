using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundCounterManager : MonoBehaviour
{
    public static RoundCounterManager Instance;
    public int round;
    public GameManager gameManager;
    public ScoreCounter scoreCounter;
    private int initialAmmo;
    private int maxEnemies;
    [SerializeField] bool roundComplete = false;
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
        roundComplete = false;
        round = 1;
        gameManager = FindAnyObjectByType<GameManager>();
        scoreCounter= FindAnyObjectByType<ScoreCounter>();
        initialAmmo = gameManager.enemiesCanSpawn;
        maxEnemies = gameManager.enemiesMaxOnScene;
                
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != "Cesar")
        {
            round = 0;
            ScoreCounter.Score = 0;

        }

        if (!roundComplete && gameManager.enemiesCanSpawn <= 0 && gameManager.enemiesOnTheScene <= 0)
        {
           RoundSucceeded();
           roundComplete = true;
        }

        else if (gameManager.enemiesCanSpawn > 0)
        {
            roundComplete = false;  
        }
    }

    public void RoundSucceeded()
    {
        round++;
                
        Debug.Log("DEBE SUMAR EN GAMEMANAGER");
        gameManager.enemiesCanSpawn = initialAmmo +((round/3) * 2);
        gameManager.enemiesMaxOnScene = maxEnemies + ((round / 3) * 4);
                
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
