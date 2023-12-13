 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerShield : MonoBehaviour
{
    [SerializeField]
    private float shieldTimer;
    [SerializeField]
    public float shieldTurnOff = 8f;
    PlayerLife player;
    [SerializeField]
    private float knockbackForce;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        shieldTimer = 0f;
    }
    void Update()
    {
        ShieldActive();

        transform.position = player.transform.position;
    }

    void ShieldActive()
    {
        player.invulnerableState = true;
        shieldTimer += Time.deltaTime;

        if (shieldTimer > shieldTurnOff)
        {
            player.invulnerableState = false;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direccionEmpuje = transform.forward;
                rb.AddForce(direccionEmpuje * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}
