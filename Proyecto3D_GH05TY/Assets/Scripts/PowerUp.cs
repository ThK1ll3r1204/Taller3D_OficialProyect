using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpsList
{
    Dispersion,
    Cadencia,
    Escudo,
    Vida,
    NoPower
}

public class PowerUp : MonoBehaviour
{
    PlayerShoot playerShootScript;
    PlayerLife playerLifeScript;
    MonoBehaviour dispersionPowerUpScript;
    public PowerUpsList activePowerUp;
    public GameObject shieldPrefab;


    void Start()
    {
        activePowerUp = PowerUpsList.NoPower;
        playerLifeScript = GetComponent<PlayerLife>();
        playerShootScript = GetComponent<PlayerShoot>();
        dispersionPowerUpScript = GetComponent<PlayerShootDispersion>();
    }

    void Update()
    {
        switch(activePowerUp)
        {
            case PowerUpsList.Dispersion:
                playerShootScript.shootingRate = 0.3f;
                dispersionPowerUpScript.enabled = true;
                break;

            case PowerUpsList.Cadencia:
                dispersionPowerUpScript.enabled = false;
                playerShootScript.shootingRate = 0.1f;
                break;

            case PowerUpsList.Escudo:
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                Vector3 playerPosition = transform.position;
                GameObject shield = Instantiate(shieldPrefab, playerPosition, Quaternion.identity);
                shield.transform.parent = player.transform;
                activePowerUp = PowerUpsList.NoPower;
                break;

            case PowerUpsList.Vida:
                playerLifeScript.currentLife += 10;
                activePowerUp = PowerUpsList.NoPower;
                break;

            default:
                break;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("PowerUpDispersion"))
        {
            activePowerUp = PowerUpsList.Dispersion;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.name == ("PowerUpCadencia"))
        {
            activePowerUp = PowerUpsList.Cadencia;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.name == ("PowerUpEscudo"))
        {
            activePowerUp = PowerUpsList.Escudo;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.name == ("PowerUpVida"))
        {
            activePowerUp = PowerUpsList.Vida;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("EnemyBullet"))
        {
            activePowerUp = PowerUpsList.NoPower;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            activePowerUp = PowerUpsList.NoPower;
        }
    }
}
