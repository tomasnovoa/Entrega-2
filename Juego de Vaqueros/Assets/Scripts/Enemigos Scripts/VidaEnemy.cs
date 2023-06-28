using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    public int hp;
    public Animator animatordaño;
    public GameObject prefabSpawn;
    public float spawnFrequency = 0.45f; // Frecuencia de spawneo del prefab (45%)
    private int destroyCount = 0; // Contador de destrucciones

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            animatordaño.Play("EnemigoHit");
            hp -= 10;
        }
    }

    private void Update()
    {
        if (hp <= 0)
        {
            destroyCount++; // Incrementar el contador de destrucciones

            if (Random.value <= spawnFrequency) // Comprobar si el valor aleatorio es menor o igual a la frecuencia de spawneo
            {
                SpawnPrefab();
            }

            Destroy(gameObject);
        }
    }

    private void SpawnPrefab()
    {
        if (prefabSpawn != null)
        {
            Instantiate(prefabSpawn, transform.position, Quaternion.identity);
        }
    }
}
