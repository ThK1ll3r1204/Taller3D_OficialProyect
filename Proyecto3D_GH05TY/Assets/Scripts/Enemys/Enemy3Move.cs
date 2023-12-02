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
    public bool enableLastBehaviour = false;

    public GameObject enemyBulletPrefab;
    [SerializeField]
    float shootRate;
    [SerializeField]
    float shootNow;
    [SerializeField]
    float enemyBulletSpeed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        ChangeDirection();
    }

    private void Update()
    {
        Movement();

        if(enableLastBehaviour == true)
        {
            LastBehaviour();
        }
        
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

    void LastBehaviour()
    {
        shootNow += Time.deltaTime;

        if (shootNow >= shootRate && player != null)
        {
            GameObject newProjectile = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
            Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
            Vector3 playerDirection = (player.position - transform.position).normalized;
            projectileRigidbody.velocity = playerDirection * enemyBulletSpeed;
            shootNow = 0f;
        }
    }
}

