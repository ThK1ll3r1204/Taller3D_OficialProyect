using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] int maxLife;
    [SerializeField] int courrentLife;
    
    void Start()
    {

    }

    void Update()
    {
        
    }

    void ChangeLife(int life)
    {
        courrentLife += life;

        if (courrentLife > maxLife)
        {
            courrentLife = maxLife;
        }

        if(life<=0)
        {
            Destroy(gameObject, 2f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerBullet"))
        {
            ChangeLife(-1);
        }
    }

}
