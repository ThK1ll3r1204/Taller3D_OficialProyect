using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviourA : MonoBehaviour
{
    private Vector3 startPoint;
    
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletMaxRange;
    [SerializeField] private string collisionTag;
    public int Damage;
    
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
        transform.Translate(bulletSpeed * Vector3.forward * Time.deltaTime );

        if (Vector3.Distance(startPoint, transform.position) > bulletMaxRange)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(collisionTag))
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);

        }
    }
}
