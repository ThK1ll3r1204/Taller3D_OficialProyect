using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform viewTarget;
    [SerializeField] private Vector3 TargetOffset;
    [SerializeField] private float cameraSpeed;
    void Awake()
    {
        viewTarget= GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        if (viewTarget != null)
        {
            transform.position = Vector3.Lerp(transform.position, viewTarget.position + TargetOffset, cameraSpeed * Time.deltaTime);

        }
    }
}
