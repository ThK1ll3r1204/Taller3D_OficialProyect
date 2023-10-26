using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] Rigidbody rb;
    [SerializeField] float velocidad;
    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject LightBulletPrefab;
    [SerializeField] GameObject DarkBulletPrefab;

    [SerializeField] float shootingRate;
    private float canShoot = 0;


    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        PlayerCanRotate();
        PlayerShoot();
    }

    void Movement()
    {
        Transform camTransform = Camera.main.transform;

        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = forward * movimientoVertical + right * movimientoHorizontal;
        movimiento.Normalize();
        rb.velocity = movimiento * velocidad;

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
