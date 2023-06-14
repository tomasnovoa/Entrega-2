using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public Transform player;                 // Referencia al objeto del jugador
    public Transform shootingPoint;          // Punto desde donde se disparará el proyectil
    public GameObject bala;      // Prefab del proyectil
    public float shootingRange = 5f;         // Rango de disparo
    public float shootingInterval = 2f;       // Intervalo de tiempo entre disparos
    private float lastShootTime;              // Tiempo del último disparo

    private void Start()
    {
        lastShootTime = Time.time;
    }

    private void Update()
    {
        // Verificar si el jugador está dentro del rango de disparo
        if (Vector2.Distance(transform.position, player.position) <= shootingRange)
        {
            // Verificar si ha pasado el tiempo suficiente desde el último disparo
            if (Time.time - lastShootTime >= shootingInterval)
            {
                Shoot();
                lastShootTime = Time.time; // Actualizar el tiempo del último disparo
            }
        }
    }

    private void Shoot()
    {
        // Crear un proyectil a partir del prefab
        GameObject balita = Instantiate(bala, shootingPoint.position, Quaternion.identity);

        
    }
}

