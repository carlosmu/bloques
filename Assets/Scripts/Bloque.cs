using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    // Creamos una variable para guardar la referencia de las partículas
    [SerializeField] private GameObject efectoParticulas;

    public Puntos puntos;

    private void OnCollisionEnter()
    {
        // En la colisión
        // Instanciamos el efecto de partículas, en la posición del transform del bloque, y su rotación
        Instantiate(efectoParticulas, transform.position, Quaternion.identity);
        // Destruimos el bloque
        Destroy(gameObject);

        //
        puntos.GanarPuntos();
    }
}
