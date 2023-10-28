using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Light,
    Dark
}
public class EnemyLife : MonoBehaviour
{
    [SerializeField] int maxLife;
    [SerializeField] int currentLife;
    [SerializeField] EnemyType activeEnemyType;

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

        if(currentLife<=0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerBullet"))
        {
            BulletBehaviourA playerBullet = other.gameObject.GetComponent<BulletBehaviourA>();
            int damageRecieved = playerBullet.Damage;
            ChangeLife(-damageRecieved);
        }
        

    }

}
