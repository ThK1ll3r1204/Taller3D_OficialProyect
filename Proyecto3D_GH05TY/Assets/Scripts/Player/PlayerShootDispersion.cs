using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootDispersion : PlayerShoot
{
    protected override void PlayerShooting()
    {
        canShoot += Time.deltaTime;

        if (Input.GetMouseButton(0) && canShoot > shootingRate)
        {
            ShootBullet(0, LightBulletPrefab);
            ShootBullet(-15, LightBulletPrefab);
            ShootBullet(15, LightBulletPrefab);
            canShoot = 0;
        }
        else if (Input.GetMouseButton(1) && canShoot > shootingRate)
        {
            ShootBullet(0, DarkBulletPrefab);
            ShootBullet(-15, DarkBulletPrefab);
            ShootBullet(15, DarkBulletPrefab);
            canShoot = 0;
        }
    }

    protected void ShootBullet(float angleOffset, GameObject bulletPrefab)
    {
        Quaternion rotation = Quaternion.Euler(0, angleOffset, 0);
        Vector3 shootingDirection = rotation * shootingPoint.forward;
        Instantiate(bulletPrefab, shootingPoint.position, Quaternion.LookRotation(shootingDirection));
    }
}
