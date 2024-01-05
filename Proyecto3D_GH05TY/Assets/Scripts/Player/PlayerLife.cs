using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public ParticleSystem deathFeedback;
    public int maxLife;
    public int currentLife;
    [SerializeField] public bool invulnerableState;
    public Transform spawn;
    ScoreCounter scoreScript;

    void Start()
    {
        invulnerableState = false;
        spawn = GameObject.Find("Spawn").GetComponent<Transform>();
        scoreScript = GameObject.Find("ScoreManager").GetComponent<ScoreCounter>();
    }

    void Update()
    {
        if (currentLife <= 0)
        {
            deathFeedback.Play();
            scoreScript.SaveHighScore();
            SceneManager.LoadScene("MENUof");
            Destroy(gameObject);

        }

        ChangeMaxLife();
    }

    protected virtual void ChangeLife(int life)
    {
        currentLife += life;

        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
               

    }

    void ChangeMaxLife()
    {
        if (maxLife <= 5)
        {
            maxLife = 5;
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (invulnerableState == false && collision.gameObject.CompareTag("Enemy"))
        {
            ChangeLife(-1);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (invulnerableState == false && other.gameObject.CompareTag("EnemyBullet"))
        {
            BulletBehaviourA enemyBullet = other.gameObject.GetComponent<BulletBehaviourA>();
            int damageRecieved = enemyBullet.Damage;
            ChangeLife(-damageRecieved);
        }

        if (other.gameObject.CompareTag("DeadZone"))
        {
            transform.position = spawn.position;
            ChangeLife(-2);
        }
    }



}
