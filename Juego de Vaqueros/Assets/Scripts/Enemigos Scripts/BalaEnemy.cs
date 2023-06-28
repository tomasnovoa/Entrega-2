using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemy : MonoBehaviour
{
    public float speed = 10f;  // Velocidad del proyectil
    private Transform player;  // Referencia al transform del jugador
    public float DestroyDelay = 3;
    private Rigidbody2D rb;

    private void Start()
    {
        DestroyProjectile(DestroyDelay);
        GameObject playerObject = GameObject.Find("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        // Determinar la dirección y escala del proyectil al instanciarlo
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = Vector2.right * speed;
        }
        else if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = Vector2.left * speed;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void DestroyProjectile(float destroyDelay)
    {
        // Destruir el proyectil después de un cierto tiempo (delay)
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
        }
    }
}
