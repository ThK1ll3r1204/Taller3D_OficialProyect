using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject LightBulletPrefab;
    [SerializeField] GameObject DarkBulletPrefab;
    [SerializeField] float shootingRate;
    private float canShoot = 0;

    void Start()
    {
        
    }

    void Update()
    {
        PlayerShooting();
    }

    void PlayerShooting()
    {
        canShoot += Time.deltaTime;

        if (Input.GetMouseButton(0) && canShoot > shootingRate)
        {
            Instantiate(LightBulletPrefab, shootingPoint.position, shootingPoint.rotation);
            canShoot = 0;
        }
        else if (Input.GetMouseButton(1) && canShoot > shootingRate)
        {
            Instantiate(DarkBulletPrefab, shootingPoint.position, shootingPoint.rotation);
            canShoot = 0;
        }
    }
}
