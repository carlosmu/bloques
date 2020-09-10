using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpezarPartida : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Puntos.puntos = 0;
            Vidas.vidas = 3;
            Application.LoadLevel("Nivel_01");
        }
    }
}
