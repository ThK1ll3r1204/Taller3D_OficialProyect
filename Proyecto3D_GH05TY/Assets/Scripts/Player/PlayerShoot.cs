using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] protected Transform shootingPoint;
    [SerializeField] protected GameObject LightBulletPrefab;
    [SerializeField] protected GameObject DarkBulletPrefab;
    [SerializeField] AudioClip disparodeluz;
    [SerializeField] AudioClip disparooscuro;
    public float shootingRate;
    protected float canShoot = 0;

    void Start()
    {
        
    }

    void Update()
    {
        PlayerShooting();
    }

    protected virtual void PlayerShooting()
    {
        canShoot += Time.deltaTime;

        if (Input.GetMouseButton(0) && canShoot > shootingRate)
        {
            Instantiate(LightBulletPrefab, shootingPoint.position, shootingPoint.rotation);
            canShoot = 0;
            GetComponent<AudioSource>().PlayOneShot(disparodeluz);

        }
        else if (Input.GetMouseButton(1) && canShoot > shootingRate)
        {
            Instantiate(DarkBulletPrefab, shootingPoint.position, shootingPoint.rotation);
            canShoot = 0;
            GetComponent<AudioSource>().PlayOneShot(disparooscuro);
        }
    }
}
