using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerLife playerLifeScript;
    [SerializeField] float velocidad;
    [SerializeField] bool terrain;
    private Vector3 lastMoveDirection = Vector3.forward;
    [SerializeField]
    public float dashDistance = 5.0f; 
    [SerializeField]
    public float dashDuration = 0.5f; 
    [SerializeField]
    float dashCooldown = 2.0f; 
    private bool canDash = true;
    public bool isCollidingWithSlippery = false;
    public bool isCollidingWithSlow = false;
    [SerializeField] private float stoppingSpeed = 2.0f;
    private float slipperyTimer = 2f;
    private float slipperySpeed = 4f;


    void Start()
    {
        rb= GetComponent<Rigidbody>();
        playerLifeScript = GetComponent<PlayerLife>();
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
            slipperyTimer = 2;
        }
        float y = rb.velocity.y;
        rb.velocity = (movimiento * velocidad)+new Vector3(0,y,0);

        //Slippery
        if (isCollidingWithSlippery == true && movimiento == Vector3.zero)
        {
            SlipperyFriction();
        }

        //Slow
        if (isCollidingWithSlow == true)
        {
            velocidad = 5f;
        }
        else if (isCollidingWithSlow == false)
        {
            velocidad = 10f;
        }
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

    void SlipperyFriction()
    {
        slipperyTimer -= Time.deltaTime;
        if (slipperyTimer >= 0)
        {
            Debug.Log("Toco Slippery");
            Vector3 oldVelocity = rb.velocity;
            rb.velocity = rb.velocity + lastMoveDirection * slipperyTimer * slipperySpeed;
        }
        

    }

}
