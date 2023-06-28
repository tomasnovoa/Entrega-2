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
    public int Balas;
    public int tiros;
    public Animator animator;
    public Animator animatorRevolver;
    private UiManager uiManager;
    public float lastShootTime;
    public float cooldownTime;

    
    public bool Cargada;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        uiManager = FindObjectOfType<UiManager>();
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
            transform.localScale = new Vector3(1, 1, 1);
            animator.Play("PlayerCaminando");
        }
        else if (moveHorizontal > 0)
        {
            transform.Translate(Vector3.right * moveHorizontal * speed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
            animator.Play("PlayerCaminando");
        }

        // Normalizar el vector de movimiento para mantener una velocidad constante en diagonal
        movement.Normalize();

        // Mover al jugador en la dirección calculada
        rb.velocity = movement * speed;




        spawnTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && Cargada)
        {
            Shoot();
        }

        if ( tiros <= 0)
        {
            Cargada = false;
        }


        Recargar();


        uiManager.SetRecarga(Balas);
        uiManager.SetTiros(tiros);

    }

    private void Shoot()
    {
        if (Time.time >= lastShootTime + cooldownTime)
        {
            animatorRevolver.Play("TiroRevolver");
            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
            tiros -= 1;
            lastShootTime = Time.time;
        }

    }

    void Recargar()
    {
        if(Balas >= 10 && (Input.GetKey(KeyCode.R)))
        {
            Cargada = true;
            Balas = 0;
            tiros += 10;
            animator.Play("PlayerRecargando");
            animatorRevolver.Play("RecargaRevolver");

            
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ammo"))
        {
            Balas += 10;
            Destroy(collision.gameObject);
        }
        
    }










}
