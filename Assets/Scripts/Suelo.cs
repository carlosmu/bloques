using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{
    // Acá ponemos la referencia del "Gestor del juego"
    [SerializeField] private Vidas vidas;

    private void OnTriggerEnter()
    {
        // Llamamos el método perder vidas una vez que la pelota tocó el suelo
        vidas.PerderVida();
    }
}
