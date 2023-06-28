using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaVidaPlayer : MonoBehaviour
{
    public int vida;
    public int tiempomuerte = 3;
    public Animator animatorhit;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaEnemy"))
        {
            animatorhit.Play("PlayerHit");
            vida -= 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            animatorhit.Play("PlayerMuerte");
            Destroy(gameObject,tiempomuerte);
        }
    }
}
