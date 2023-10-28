using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] int maxLife;
    public int currentLife;
    
    void Start()
    {

    }

    void Update()
    {
        
    }

    protected virtual void ChangeLife(int life)
    {
        currentLife += life;

        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ChangeLife(-1);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            BulletBehaviourA enemyBullet = other.gameObject.GetComponent<BulletBehaviourA>();
            int damageRecieved = enemyBullet.Damage;
            ChangeLife(-damageRecieved);
        }
    }

}
