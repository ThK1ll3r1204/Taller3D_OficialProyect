using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] int maxLife;
    [SerializeField] int courrentLife;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

        if (life <= 0)
        {
            Destroy(gameObject, 2f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            ChangeLife(-1);
        }
    }

}
