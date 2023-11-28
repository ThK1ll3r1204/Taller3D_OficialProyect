using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public GameObject PEffect;

    public float dieTime;

    void Start()
    {
        StartCoroutine(Timer());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name != "Character placeholder")
        {
            Die();
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }


    void Die()
    {
        if (PEffect != null)
        {
            Instantiate(PEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
