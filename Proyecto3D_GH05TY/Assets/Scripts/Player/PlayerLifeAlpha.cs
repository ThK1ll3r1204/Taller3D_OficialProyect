using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeAlpha : MonoBehaviour
{
    public int Plife = 5;

    void Update()
    {
        if (Plife <= 0)
        {
            SceneManager.LoadScene("Menu");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Plife -= 1;
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Plife -= 1;
        }
    }
}