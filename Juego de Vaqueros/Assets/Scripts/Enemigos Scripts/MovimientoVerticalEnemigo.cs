using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoVerticalEnemigo : MonoBehaviour
{
    public float waitTime = 5;
    private float timer;
    public Transform player;
    public float moveSpeed;
    Vector3 targetPos;
    public Animator animator;
    public Animator pistolaAnimator;
    private bool isIdle;

    private void Start()
    {
        targetPos = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            // Actualizar posición
            timer = 0;
            targetPos.y = player.position.y;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (transform.position == targetPos)
        {
            if (!isIdle)
            {
                isIdle = true;
                animator.Play("EnemigoTiro");
            }
        }
        else
        {
            isIdle = false;
            animator.Play("EnemigoCaminando");
            pistolaAnimator.Play("RevolverEnemigoNoEsta");
        }


        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Girar hacia el jugador si está a la izquierda
        else if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }





}
