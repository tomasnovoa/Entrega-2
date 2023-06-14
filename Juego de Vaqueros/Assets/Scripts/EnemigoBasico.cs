using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBasico : MonoBehaviour
{
    public Transform player; // Referencia al objeto del jugador
    public float moveSpeed = 3f; // Velocidad de movimiento del enemigo
    public float attackRange = 5f; // Rango de ataque del enemigo
    public float attackInterval = 5f; // Intervalo de tiempo entre disparos
    public GameObject bulletPrefab; // Prefab del proyectil que dispara el enemigo
    public Transform firePoint; // Punto de origen del disparo

    private bool isAttacking = false; // Indica si el enemigo está atacando actualmente

    private void Start()
    {
        StartCoroutine(AttackPlayer()); // Inicia la rutina de ataque al jugador
    }

    private void Update()
    {
        // Calcula la dirección hacia el jugador
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // Mueve el enemigo hacia el jugador
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Si el jugador está dentro del rango de ataque, ataca
        if (Vector3.Distance(transform.position, player.position) <= attackRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;

        // Apunta al jugador
        transform.right = player.position - transform.position;

        // Espera un tiempo antes de disparar
        yield return new WaitForSeconds(0.5f);

        // Dispara
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);

        // Espera el intervalo de tiempo antes de permitir otro ataque
        yield return new WaitForSeconds(attackInterval);

        isAttacking = false;
    }

    private IEnumerator AttackPlayer()
    {
        while (true)
        {
            // Espera un intervalo de tiempo antes de actualizar la posición del enemigo
            yield return new WaitForSeconds(5f);

            // Calcula la nueva posición para acercarse al jugador
            Vector3 newPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);

            // Se mueve hacia la nueva posición
            while (Vector3.Distance(transform.position, newPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
