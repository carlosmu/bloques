using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosFinPartida : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;   // Referencia al componente AudioSource del Gestor del Juego
    [SerializeField] private AudioClip completado;      // Clip que usaremos para nivel completado
    [SerializeField] private AudioClip gameOver;        // Clip para gameOver

    // Es público para que lo podamos llamar desde otros scripts
    public void GameOver()
    {
        ReproduceSonido(gameOver);      // Llamamos al método y asignamos la variable gameOver
    }

    // Es público para que lo podamos llamar desde otros scripts
    public void NivelCompletado()
    {
        ReproduceSonido(completado);    // Llamamos al método y asignamos la variable completado
    }

    // No nos interesa que sea público
    void ReproduceSonido(AudioClip sonido)  // Creamos el método y como parámetro le pasamos un AudioClip, "sonido"
    {
        audioSource.clip = sonido;          // Acá metemos ese parámetro
        audioSource.loop = false;           // Le sacamos el loop a la reproducción (viene del sonido de la música)
        audioSource.Play();                 // Reproducimos el nuevo sonido
    }
}
