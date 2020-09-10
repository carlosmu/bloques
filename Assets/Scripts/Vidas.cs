using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    // Las vidas iniciales. Es estática para que haya una sola
    public static int vidas = 3;

    // El texto donde van las vidas
    [SerializeField] private Text textoVidas;

    // Referencia a la Pelota
    // Lo que queremos es acceder al script, para llamar a métodos que hay ahí
    [SerializeField] private Pelota pelota;

    // Referencia a la Barra
    // Lo que queremos es acceder al script, para llamar a métodos que hay ahí
    [SerializeField] private Barra barra;

    // Start is called before the first frame update
    void Start()
    {
        // Actuallizamos el Marcador
        ActualizarMarcadorVidas();
    }

    void ActualizarMarcadorVidas()
    {
        // Actuallizamos el Marcador
        textoVidas.text = "Vidas: " + Vidas.vidas;
    }

    public void PerderVida()
    {
        // Reducimos las vidas en 1
        Vidas.vidas--;
        // Actualizamos el marcador de vidas
        ActualizarMarcadorVidas();

        // Acá hacemos el Reset de la pelota y la barra. 
        // Esto es posible porque previamente referenciamos a ambos, al principio de este script.
        barra.Reset();        
        pelota.Reset();

    }
}
