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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        round++;
    }
}
