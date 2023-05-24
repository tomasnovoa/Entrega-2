using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // Velocidad del proyectil
    public bool moveRight = true;  // Variable para controlar la dirección del movimiento

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Calcular la dirección del movimiento en base a la variable moveRight
        Vector2 movement = moveRight ? Vector2.right : Vector2.left;

        // Mover el proyectil en la dirección calculada
        rb.velocity = movement * speed;

    }

}
