using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] NavMeshAgent agent;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {        
        _player = GameObject.Find("Player").GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();

        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (_player != null)
        {
            _player = GameObject.Find("Player").GetComponent<Transform>();
            agent.destination = _player.position;
        }
        else
        {
            return;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerShield"))
        {
            agent.speed = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerShield"))
        {
            agent.speed = 3.5f;
        }
    }

}
