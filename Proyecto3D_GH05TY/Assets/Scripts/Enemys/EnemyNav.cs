using System.Collections;
using System.Collections.Generic;
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
        FollowPlayer();
        
    }

    void FollowPlayer()
    {
        if (_player != null)
        {
            _player = GameObject.Find("Player").GetComponent<Transform>();
            agent.destination = _player.position;
        }
        
    }

    

}
