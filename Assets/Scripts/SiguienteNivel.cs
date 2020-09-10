using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguienteNivel : MonoBehaviour
{
    // Nivel a cargar (asignada desde el inspector)
    [SerializeField] public string nivelACargar = "Portada";

    [SerializeField] private float retraso = 5;

 
    // ContextMenu, para activar el método siguiente (ActivarCarga()) para probar.
    // ESto solo funcionará con métodos que no reciben ningún parámetro.
    [ContextMenu("Activar Carga")]
    // Void es porque no devuelve nada
    // Publico porque lo activamos desde otros scripts
    // Este es el método que llamaremos desde otros scripts
    public void ActivarCarga()
    {
        // Invoke lo que hace es esperar un x-tiempo y luego llamar al método indicado.
        Invoke("CargarNivel", retraso);
    }

    // Acá en este método por ejemplo no ponemos public porque solo se llama desde este script.
    // También podríamos poner private.
    void CargarNivel()
    {
        Application.LoadLevel(nivelACargar);
    }

    // Acá en este método en vez de "void" ponemos "bool" porque sí queremos devolver algo.
    // En este caso queresmo devolver True o False.
    public bool EsUltimoNivel()
    {
        if(nivelACargar == "Portada")
        {
            return true;
        }
        else
        {
            return false;
        }

        // Una forma corta de escribir lo mismo (pero más difícil de leer) es la siguiente:
        // return nivelACargar == "Portada";
    }

}
