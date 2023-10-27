using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float changeDirectionInterval;
    [SerializeField]
    private float timeSinceLastDirectionChange;
    private Vector3 moveDirection;

    void Start()
    {
        ChangeMoveDirection();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Mueve al enemigo en la dirección actual.
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Actualiza el temporizador para el cambio de dirección.
        timeSinceLastDirectionChange += Time.deltaTime;

        // Verifica si es hora de cambiar de dirección.
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            ChangeMoveDirection();
        }
    }
    
    void ChangeMoveDirection()
    {
        // Genera una nueva dirección de movimiento aleatoria en los ejes X y Z.
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

        // Reinicia el temporizador.
        timeSinceLastDirectionChange = 0.0f;
    }
}

