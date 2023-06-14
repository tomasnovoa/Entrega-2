using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemy : MonoBehaviour
{
    public float speed = 10f;  // Velocidad del proyectil
    private Transform Enemy;  // Referencia al transform del jugador
    public float DestroyDelay = 3;
    private Rigidbody2D rb;

    private void Start()
    {
        DestroyProjectile(3f);
        rb = GetComponent<Rigidbody2D>();

        // Buscar el transform del jugador por su nombre
        GameObject EnemyObject = GameObject.Find("Enemy");

        if (EnemyObject != null)
        {
             Enemy = EnemyObject.transform;
        }
        else
        {
            Debug.LogError("Enemy");
        }


        // Verificar si se encontró el transform del jugador
        if (Enemy != null)
        {
            // Calcular la dirección del movimiento en base a la escala del jugador
            Vector2 movement = Vector2.right;  // Dirección predeterminada

            if (Enemy.localScale.x < 0)
            {
                // Jugador mira hacia la izquierda, invertir la dirección del movimiento
                movement = Vector2.left;
            }

            // Mover el proyectil en la dirección calculada
            rb.velocity = movement * speed;
        }
    }

    private void Update()
    {

    }

    private void DestroyProjectile(float DestroyDelay)
    {
        // Destruir el proyectil después de un cierto tiempo (delay)
        Destroy(gameObject, DestroyDelay);
    }
}
