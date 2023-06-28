using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pausa el tiempo en el juego
        isPaused = true;

        // Aqu� puedes agregar cualquier otra l�gica espec�fica de pausa, como mostrar un men� de pausa, desactivar controles, etc.

        Debug.Log("Juego pausado");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Restaura el tiempo en el juego
        isPaused = false;

        // Aqu� puedes agregar cualquier otra l�gica espec�fica de despausa, como ocultar el men� de pausa, reactivar controles, etc.

        Debug.Log("Juego reanudado");
    }
}
