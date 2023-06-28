using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // Velocidad del proyectil
    private Transform playerTransform;  // Referencia al transform del jugador
    public float DestroyDelay = 3;
    private Rigidbody2D rb;

    private void Start()
    {
        DestroyProjectile(3f);
        rb = GetComponent<Rigidbody2D>();

        // Buscar el transform del jugador por su nombre
        GameObject playerObject = GameObject.Find("Player");

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player");
        }


        // Verificar si se encontr� el transform del jugador
        if (playerTransform != null)
        {
            // Calcular la direcci�n del movimiento en base a la escala del jugador
            Vector2 movement = Vector2.right;  // Direcci�n predeterminada

            if (playerTransform.localScale.x > 0)
            {
                // Jugador mira hacia la izquierda, invertir la direcci�n del movimiento
                movement = Vector2.left;
                // Girar la escala del proyectil en el eje X
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            // Mover el proyectil en la direcci�n calculada
            rb.velocity = movement * speed;
        }
    }

    private void Update()
    {
       
    }

    private void DestroyProjectile(float DestroyDelay)
    {
        // Destruir el proyectil despu�s de un cierto tiempo (delay)
        Destroy(gameObject, DestroyDelay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }


}
