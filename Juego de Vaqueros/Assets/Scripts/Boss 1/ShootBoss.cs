using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBoss : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public float fireRate = 1.0f;
    public float projectileSpeed = 5.0f;
    public int DestruirBala;
    public float shootingRange = 10.0f;

    private float fireTimer = 0.0f;

    private void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.position) <= shootingRange)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            fireTimer += Time.deltaTime;

            if (fireTimer >= 1.0f / fireRate)
            {
                fireTimer = 0.0f;
                FireProjectile(direction);
            }
        }
    }

    private void FireProjectile(Vector2 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        projectile.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = direction.normalized * projectileSpeed;

        Destroy(projectile, DestruirBala);
    }



}
