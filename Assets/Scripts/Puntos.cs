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

    // Acá hago referencia al objeto de "Nivel Completado", que contiene el texto
    [SerializeField] private GameObject nivelCompletado;

    // Acá hago referencia al objeto de "Juego Completado", que contiene el texto
    [SerializeField] private GameObject juegoCompletado;

    // Acá hago referencia al Script de "Siguiente Nivel"
    [SerializeField] private SiguienteNivel siguienteNivel;

    // Acá hago referencia al Script de la pelota.
    [SerializeField] private Pelota pelota;

    // Acá hago referencia al transform del contenedor de Bloques
    [SerializeField] private Transform contenedorBloques;

    // Me faltó esta.. para que funcione el if final de "ganar puntos".
    [SerializeField] private Barra barra;

    [SerializeField] private SonidosFinPartida sonidosFinPartida; // Acá vamos a asignar la referencia al script "sonidosfinpartida"
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

        // Si el contenedor de bloques tiene 0 hijos o menos...
        if(contenedorBloques.childCount<= 0)
        {
            // Hacemos referencia a la pelota y detenemos su movimiento.
            pelota.DetenerMovimiento();

            // Deshabilitamos la barra
            // No usamos "SetActive" en este caso, como en gameOver. Porque en ese caso hace ref a un objeto
            // Pero acá hace referencia a un componente, que es el script de Barra.
            barra.enabled = false;


            // Si es último nivel activar "Juego  Completado".
            if (siguienteNivel.EsUltimoNivel())
            {
                juegoCompletado.SetActive(true);
            }
            // Sino Activar "nivel completado".
            else
            {
                nivelCompletado.SetActive(true);
            }

            sonidosFinPartida.NivelCompletado();
            siguienteNivel.ActivarCarga();
        }
    }

}
