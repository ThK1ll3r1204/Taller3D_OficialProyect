using UnityEngine.AI;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform player;
    public GameObject enemyBulletPrefab;
    [SerializeField]
    float shootRate;
    [SerializeField]
    float shootNow;
    [SerializeField]
    float enemyBulletSpeed;
    [SerializeField] float detectionRadius = 5f;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float distance;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        

        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);

        if (colliders.Length > 0 )
        {
            agent.speed = 0.25f;
        }
        else
        {
            agent.speed = 3.5f;
        }
        if (Vector3.Distance(transform.position, player.position) >= distance)
        {
            return;
        }

        ShootProjectile();
    }

    void ShootProjectile()
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z), detectionRadius);
    }

}
