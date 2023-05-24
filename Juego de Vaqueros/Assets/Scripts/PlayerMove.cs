using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento del jugador
    
    private Rigidbody2D rb;
    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform spawnPoint;  // Punto de origen para instanciar los proyectiles
    public float spawnInterval = 1f;  // Intervalo de tiempo entre cada instancia de proyectil
    private float spawnTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Obtener la entrada del usuario en el eje horizontal y vertical
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
       
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Calcular la dirección de movimiento
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (moveHorizontal < 0)
        {
            transform.Translate(Vector3.right * moveHorizontal * speed * Time.deltaTime);
            transform.localScale = moveHorizontal > 0 ? Vector3.one : new Vector3(-1, 1, 1); ;
        }
        if (moveHorizontal > 0)
        {
            transform.Translate(Vector3.right * moveHorizontal * speed * Time.deltaTime);
            transform.localScale = moveHorizontal > 0 ? Vector3.one : new Vector3(-1, 1, 1);
        }

        // Normalizar el vector de movimiento para mantener una velocidad constante en diagonal
        movement.Normalize();

        // Mover al jugador en la dirección calculada
        rb.velocity = movement * speed;




        spawnTimer += Time.deltaTime;

        // Verificar si es momento de instanciar un proyectil
        if (spawnTimer >= spawnInterval)
        {
            SpawnProjectile();
            spawnTimer = 0f;  // Reiniciar el temporizador
        }



    }

    private void SpawnProjectile()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);// Instanciar un proyectil en el spawnPoint
        }

        

        
    }







}
