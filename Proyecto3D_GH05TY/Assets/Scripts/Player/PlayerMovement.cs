using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    public  Transform _camera;
    public float speed = 4;
    public float gravity = -9.8f;

    [SerializeField] float canShoot;
    [SerializeField] float shootingRate;
    [SerializeField] GameObject LightBulletPrefab;
    [SerializeField] GameObject DarkBulletPrefab;
    [SerializeField] Transform shootingPoint;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 movement = Vector3.zero;
        float movementSpeed = 0;

        if (hor != 0 || ver != 0)
        {
            Vector3 forward = _camera.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = _camera.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * ver + right * hor;
            movementSpeed = Mathf.Clamp01(direction.magnitude);
            direction.Normalize();

            movement = direction * speed * movementSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        }

        movement.y += gravity * Time.deltaTime;

        characterController.Move(movement);

        PlayerShoot();

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
