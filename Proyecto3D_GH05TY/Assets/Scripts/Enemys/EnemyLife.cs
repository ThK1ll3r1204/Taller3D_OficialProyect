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
    [SerializeField] int pointsGiven;
    ScoreCounter scoreScript;
    GameManager gameManager;
    RoundCounterManager roundManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreScript = GameObject.Find("ScoreManager").GetComponent<ScoreCounter>();
        roundManager = GameObject.Find("RoundManager").GetComponent<RoundCounterManager>();
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
            scoreScript.scoreMultiplierTimer++;
            scoreScript.AddScore(pointsGiven);
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerLightBullet") && activeEnemyType == EnemyType.Light)
        {
            BulletBehaviourA playerBullet = other.gameObject.GetComponent<BulletBehaviourA>();
            int damageRecieved = playerBullet.Damage;
            ChangeLife(-damageRecieved * 100);
        }
        else if (other.gameObject.CompareTag("PlayerLightBullet") && activeEnemyType != EnemyType.Light)
        {
            BulletBehaviourA playerBullet = other.gameObject.GetComponent<BulletBehaviourA>();
            int damageRecieved = playerBullet.Damage;
            ChangeLife(-damageRecieved);
        }
        else if (other.gameObject.CompareTag("PlayerDarkBullet") && activeEnemyType == EnemyType.Dark)
        {
            BulletBehaviourA playerBullet = other.gameObject.GetComponent<BulletBehaviourA>();
            int damageRecieved = playerBullet.Damage;
            ChangeLife(-damageRecieved * 100);
        }
        else if (other.gameObject.CompareTag("PlayerDarkBullet") && activeEnemyType != EnemyType.Dark)
        {
            BulletBehaviourA playerBullet = other.gameObject.GetComponent<BulletBehaviourA>();
            int damageRecieved = playerBullet.Damage;
            ChangeLife(-damageRecieved);
        }
    }

}
