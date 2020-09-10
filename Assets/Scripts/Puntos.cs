using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    // Acá me re comí poner "static" y me trajo mil problemones. 
    // Porque después lo llamo como una variable estática.
    public static int puntos = 0;

    // Acá hago referencia al objeto de GUI de los puntos
    [SerializeField] private Text textoPuntos;

    private void Start()
    {
        // Llamo a actualizar los puntos.
        ActualizarMarcadoPuntos();
    }

    public void ActualizarMarcadoPuntos()
    {
        // Asignamos el string "Puntos: " + los puntos iniciales (0)
        textoPuntos.text = "Puntos: " + Puntos.puntos;
    }

    public void GanarPuntos()
    {
        // Incrementamos los puntos en 10 por cada bloque destruido
        Puntos.puntos = Puntos.puntos + 10;
        
        // Actualizamos el puntaje en la GUI
        ActualizarMarcadoPuntos();
    }

}
