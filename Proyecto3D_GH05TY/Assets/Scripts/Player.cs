using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

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
        Movement();
        PlayerCanRotate();
        PlayerShoot();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

    }

    void PlayerCanRotate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    void PlayerShoot()
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
