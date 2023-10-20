using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Vector3 startPoint;
    
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletMaxRange;
    
    void Start()
    {
        startPoint = transform.position;
    }

    void Update()
    {
        BulletMovement();
    }

    void BulletMovement()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        if (Vector3.Distance(startPoint, transform.position) > bulletMaxRange)
        {
            Destroy(this.gameObject);
        }
    }
}
