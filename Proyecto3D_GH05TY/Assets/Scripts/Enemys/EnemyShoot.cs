using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform player;
    public GameObject enemyBulletPrefab;
    [SerializeField]
    float shootRate;
    [SerializeField]
    float shootNow;
    [SerializeField]
    float enemyBulletSpeed;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        ShootProjectile();
    }

    void ShootProjectile()
    {
        shootNow += Time.deltaTime;

        if (shootNow >= shootRate && player != null)
        {
            GameObject newProjectile = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
            Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
            Vector3 playerDirection = player.position - transform.position;
            projectileRigidbody.velocity = playerDirection * enemyBulletSpeed;
            shootNow = 0f;
        }
    }
}
