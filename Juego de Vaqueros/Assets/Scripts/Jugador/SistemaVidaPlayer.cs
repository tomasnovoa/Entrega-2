using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaVidaPlayer : MonoBehaviour
{
    public int vida;
    
    public Animator animatorhit;
    public GameObject negro;
    void Start()
    {
        negro.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaEnemy"))
        {
            animatorhit.Play("PlayerHit");
            vida -= 10;
        }
    }

    
    void Update()
    {
        if (vida <= 0)
        {
            animatorhit.Play("PlayerMuerte");

            negro.SetActive(true);
        }
    }
}
