using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpsList
{
    Dispersion,
    Cadencia,
    Escudo,
    Curar,
    VidaAumentada,
    NoPower
}

public class PowerUp : MonoBehaviour
{
    [SerializeField] ParticleSystem healFeedback;
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
                activePowerUp = PowerUpsList.NoPower;
                break;

            case PowerUpsList.Curar:
                playerLifeScript.currentLife += 1;
                activePowerUp = PowerUpsList.NoPower;
                break;

            case PowerUpsList.VidaAumentada:
                playerLifeScript.maxLife += 2;
                activePowerUp = PowerUpsList.NoPower;
                break;

            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            PowerUpID powerUpAdquired = other.gameObject.GetComponent<PowerUpID>();

            if (powerUpAdquired.PowerUpIdentification == PowerUpsName.Dispersion)
            {
                activePowerUp = PowerUpsList.Dispersion;
                Destroy(other.gameObject);
            }
            else if (powerUpAdquired.PowerUpIdentification == PowerUpsName.Cadencia)
            {
                activePowerUp = PowerUpsList.Cadencia;
                Destroy(other.gameObject);
            }
            else if (powerUpAdquired.PowerUpIdentification == PowerUpsName.Escudo)
            {
                activePowerUp = PowerUpsList.Escudo;
                Destroy(other.gameObject);
            }
            else if (powerUpAdquired.PowerUpIdentification == PowerUpsName.Curar)
            {
                if (playerLifeScript.currentLife < playerLifeScript.maxLife)
                {
                    activePowerUp = PowerUpsList.Curar;
                    healFeedback.Play();
                    Destroy(other.gameObject);
                }
                
            }
            else if (powerUpAdquired.PowerUpIdentification == PowerUpsName.VidaAumentada)
            {
                activePowerUp = PowerUpsList.VidaAumentada;
                Destroy(other.gameObject);
            }
            
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
