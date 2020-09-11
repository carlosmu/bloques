using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmpezarPartida : MonoBehaviour
{
    [SerializeField] private int vidasIniciales = 3;
    [SerializeField] private ElementoInteractivo pantalla;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || pantalla.pulsado)
        {
            Puntos.puntos = 0;
            Vidas.vidas = vidasIniciales;
            SceneManager.LoadSceneAsync("Nivel_01");
        }
    }
}
