using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    
    

        public void CambiarEscena(string nombreEscena)
        {
            SceneManager.LoadScene(nombreEscena);
        }

    
}
