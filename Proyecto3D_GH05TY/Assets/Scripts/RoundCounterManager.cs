using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundCounterManager : MonoBehaviour
{
    public static RoundCounterManager Instance;
    public int round;
    public Text roundText;
    public GameManager gameManager;
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
        SceneManager.sceneLoaded += OnSceneChange;
        roundComplete = false;
        round = 1;
        gameManager = FindAnyObjectByType<GameManager>();
        initialAmmo = gameManager.enemiesCanSpawn;
        maxEnemies = gameManager.enemiesMaxOnScene;
        roundText= GameObject.Find("roundUI").GetComponent<Text>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MENUof")
        {
            Instance.round = 1;
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

        if (roundText != null)
        {
            roundText.text = "Ronda: " + round;
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

    void OnSceneChange(Scene scene, LoadSceneMode mode)
    {
        if(GameObject.Find("roundUI")!= null)
        {
            roundText = GameObject.Find("roundUI").GetComponent<Text>();
        }
    }
}
