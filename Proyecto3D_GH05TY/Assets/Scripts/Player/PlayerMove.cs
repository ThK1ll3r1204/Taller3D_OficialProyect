using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerLife playerLifeScript;
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
        playerLifeScript = GetComponent<PlayerLife>();
    }

    void Update()
    {
        rb.useGravity = true;
        Movement();
        PlayerCanRotate();

        if (canDash && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(PerformDash(lastMoveDirection));
        }
    }

    void Movement()
    {

        Transform camTransform = FindAnyObjectByType<Camera>().GetComponent<Transform>();

        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");

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
        Ray ray = FindAnyObjectByType<Camera>().ScreenPointToRay(Input.mousePosition);

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
            rb.useGravity = false;
            playerLifeScript.invulnerableState = true;

            transform.position = Vector3.Lerp(startPosition, endPosition, (Time.time - startTime) / dashDuration);

            
            yield return null;
        }
        rb.useGravity = true;
        playerLifeScript.invulnerableState = false;
        transform.position = endPosition;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

        rb.velocity = Vector3.zero;
    }

}
