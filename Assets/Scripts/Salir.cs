using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{
    public bool salir;

    // Update is called once per frame
    void Update()
    {
        // Si hemos presionado la tecla Escape...
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si Salir es true
            if (salir)
            {
                // Salir de la aplicación
                Debug.Log("Salimos del juego");
                Application.Quit();
            }
            else
            {
                // Sino (si estamos jugando), salir a la portada
                Application.LoadLevel("Portada");
            }
        }
        
    }
}
