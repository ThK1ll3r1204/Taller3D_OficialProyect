using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachToPlayer : MonoBehaviour
{
    public Transform Player;

    public float speed = 1f;

    public void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (Player != null)
        {
            Vector3 reach = Player.position - transform.position;
            reach.y = -5f;

            Quaternion hook = Quaternion.LookRotation(reach);

            transform.rotation = Quaternion.Slerp(transform.rotation, hook, speed * Time.deltaTime);
        }
    }
}