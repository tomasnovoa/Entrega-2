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


    private void Start()
    {
        targetPos = transform.position;
    }

    private void Update()
    {

        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            //actualizar pos
            timer = 0;
            targetPos.y = player.position.y;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }





}
