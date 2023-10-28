using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float changeDirectionRate;
    [SerializeField]
    private float maxDistance;
    private Vector3 randomDirection;
    [SerializeField]
    private float changeDirectionTimer;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
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
                transform.Translate(-directionToPlayer.normalized * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(randomDirection.normalized * moveSpeed * Time.deltaTime);
            }
        }
        
    }

    private void ChangeDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        randomDirection.Normalize();

        changeDirectionTimer = 0;
    }
}

