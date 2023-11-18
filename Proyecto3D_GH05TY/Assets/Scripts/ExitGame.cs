using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Start()
    {
        button.onClick.AddListener(Exit);
    }

    void Exit()
    {
        Application.Quit();
    }
}
