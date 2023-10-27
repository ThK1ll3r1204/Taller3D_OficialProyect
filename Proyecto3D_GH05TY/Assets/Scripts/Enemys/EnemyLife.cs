using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] int maxLife;
    [SerializeField] int currentLife;
    
    void Start()
    {

    }

    void Update()
    {
        
    }

    void ChangeLife(int life)
    {
        currentLife += life;

        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }

        if(life<=0)
        {
            Destroy(this.gameObject);
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
