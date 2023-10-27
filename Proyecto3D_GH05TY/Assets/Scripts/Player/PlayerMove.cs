using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] Rigidbody rb;
    [SerializeField] float velocidad;

    private Vector3 lastMoveDirection = Vector3.forward;
    [SerializeField]
    float dashDistance = 5.0f; 
    [SerializeField]
    float dashDuration = 0.5f; 
    [SerializeField]
    float dashCooldown = 2.0f; 
    private bool canDash = true; 

    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        PlayerCanRotate();

        if (canDash && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(PerformDash(lastMoveDirection));
        }
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

        if (movimiento != Vector3.zero)
        {
            lastMoveDirection = movimiento;
        }

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

    IEnumerator PerformDash(Vector3 dashDirection)
    {
        canDash = false;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + dashDirection.normalized * dashDistance;

        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, (Time.time - startTime) / dashDuration);
            yield return null;
        }

        transform.position = endPosition;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

        rb.velocity = Vector3.zero;
    }

}
