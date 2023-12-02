using System.Collections;
using UnityEngine;

public class Enemy3Move : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    [SerializeField]
    private float changeDirectionRate;
    [SerializeField]
    private float maxDistance;
    private Vector3 randomDirection;
    [SerializeField]
    private float changeDirectionTimer;
    private Rigidbody rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        ChangeDirection();
    }

    private void Update()
    {
        Movement();
        
    }

    private void Movement()
    {
        if (player != null)
        {
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

            changeDirectionTimer += Time.deltaTime;
            if (changeDirectionTimer >= changeDirectionRate)
            {
                ChangeDirection();
            }

            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0;
            float distanceToPlayer = directionToPlayer.magnitude;

            if (distanceToPlayer < maxDistance)
            {
                rb.velocity = (-directionToPlayer + randomDirection).normalized * moveSpeed;

            }
            else
            {
                rb.velocity = randomDirection.normalized * moveSpeed;
            }
        }
        
    }

    private void ChangeDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        randomDirection.Normalize();

        changeDirectionTimer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerShield"))
        {
            moveSpeed = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerShield"))
        {
            moveSpeed = 3.5f;
        }
    }
}

