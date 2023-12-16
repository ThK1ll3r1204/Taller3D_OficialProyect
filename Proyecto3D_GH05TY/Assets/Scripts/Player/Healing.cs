using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public ParticleSystem healFeedback;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HeartContainer") && healFeedback != null)
        {
            healFeedback.Play();
        }
    }
}