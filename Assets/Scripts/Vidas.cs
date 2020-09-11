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

    // Hacemos referencia al objeto "GameOver" para activarlo cuando perdemos.
    [SerializeField] private GameObject gameOver;
    // Hacemos referencia al script del Siguiente Nivel.
    [SerializeField] private SiguienteNivel siguienteNivel;

    [SerializeField] private SonidosFinPartida sonidosFinPartida; // Acá vamos a asignar la referencia al script "sonidosfinpartida"

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
        // Si vidas es igual o menor que 0 no ejecutar. 
        // Sino seguir (reducir una vida, y actualizar marcador)
        if (Vidas.vidas <= 0) return;

        // Reducimos las vidas en 1
        Vidas.vidas--;
        // Actualizamos el marcador de vidas
        ActualizarMarcadorVidas();

        // Luego.. Si vidas es igual o menor que 0, mostrar GameOver.
        if (Vidas.vidas <= 0)
        {
            // Hacemos referencia SonidosFinPartida y llamo a su método GameOver.
            sonidosFinPartida.GameOver();

            // Mostrar GameOver
            gameOver.SetActive(true);
            
            // Hacemos referencia a la pelota y detenemos su movimiento.
            pelota.DetenerMovimiento();
            
            // Deshabilitamos la barra
            // No usamos "SetActive" en este caso, como en gameOver. Porque en ese caso hace ref a un objeto
            // Pero acá hace referencia a un componente, que es el script de Barra.
            barra.enabled = false;
            // Si en cambio quisiéramos hacer referencia a su game object haríamos esto:
            // barra.gameObject.SetActive(false);

            // Sobreescribimos el "nivel a cargar" con la escena "Portada".
            siguienteNivel.nivelACargar = "Portada";
            // Hacemos que cargue la escena indicada en el método Activar Carga.
            siguienteNivel.ActivarCarga();
        }

        //Sino.. resetear barra y pelota.
        else
        {
            // Acá hacemos el Reset de la pelota y la barra. 
            // Esto es posible porque previamente referenciamos a ambos, al principio de este script.
            barra.Reset();        
            pelota.Reset();
        }
    }
}
