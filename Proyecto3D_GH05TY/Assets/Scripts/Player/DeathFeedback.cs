using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFeedback : MonoBehaviour
{
    public ParticleSystem deathFeedback;

    void OnDestroy()
    {
        if (deathFeedback != null)
        {
            deathFeedback.Play();
        }
    }
}
