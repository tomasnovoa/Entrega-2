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

        // Aquí puedes agregar cualquier otra lógica específica de pausa, como mostrar un menú de pausa, desactivar controles, etc.

        Debug.Log("Juego pausado");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Restaura el tiempo en el juego
        isPaused = false;

        // Aquí puedes agregar cualquier otra lógica específica de despausa, como ocultar el menú de pausa, reactivar controles, etc.

        Debug.Log("Juego reanudado");
    }
}
