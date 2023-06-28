using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;



public class Menu : MonoBehaviour
{
    public GameObject negro;
    public float delay;
    public string nombreEscena;

    public void CambiarEscena()
    {
        negro.SetActive(true);
        Invoke("CargarEscena", delay);
    }

    private void CargarEscena()
    {
        SceneManager.LoadScene(nombreEscena);
    }

    void Start()
    {
        negro.SetActive(false);
    }


}
