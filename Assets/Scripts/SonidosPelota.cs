using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosPelota : MonoBehaviour
{
    public AudioSource rebote;    // Referencia al source de rebote
    public AudioSource punto;     // Ref al source audio de bloques
    public AudioSource muerte;     // Ref al 

    void OnCollisionEnter(Collision otro)
    {
        // Si tiene el tag "Bloque" ejecuta el sonido de puntos
        if (otro.gameObject.CompareTag("Bloque"))
        {
            punto.Play();
        }

        // Primero lo hice así, después Andy me ayudó a poner el OnTriggerEnter
        //else if (otro.gameObject.CompareTag("Suelo"))
        //{
        //    muerte.Play();
        //}

        // Sino ejecuta el otro sonido
        else
        {
            rebote.Play();
        }
    }
    private void OnTriggerEnter(Collider otro)
    {
        if (otro.gameObject.CompareTag("Suelo"))
        {
            muerte.Play();
        }
    }
}
