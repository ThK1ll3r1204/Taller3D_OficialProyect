using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : PlayerLife
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
