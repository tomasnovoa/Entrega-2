using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Reset : MonoBehaviour
{
    public void RestartScene()
    {
        // Obtiene el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reinicia la escena cargando nuevamente su índice
        SceneManager.LoadScene(currentSceneIndex);
    }
}
