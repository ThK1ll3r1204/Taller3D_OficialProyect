using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float speed = 0.5f;
    public int rotation = -360;

    void Update()
    {
        transform.Rotate(0, rotation * speed * Time.deltaTime, 0);
    }
}