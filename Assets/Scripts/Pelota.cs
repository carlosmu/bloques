using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    // Definir la fuerza inicial para empujar la pelota
    [SerializeField] private float velocidadInicial = 600f;

    // Acá vamos a asignar el transform de la barra para cuando tengamos que resetear la pelota
    // También podemos usar un parentTransform = GetComponentInParent<> y busca el componente en el padre.
    [SerializeField] private Transform parentTransform;

    // Creamos una variable para asignarle el rigidbody del objeto
    Rigidbody rig;

    // Una variable lógica para saber si el juego ya está iniciado
    private bool enJuego = false;

    // Creamos una variable para alojar la posición inicial de la pelota
    private Vector3 posicionInicial;


    private void Awake()
    {
        // Asignamos el rigidbody mediante el método getcomponent.
        rig = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {   
        // Asignamos la posición inicial a la variable
        posicionInicial = transform.position;
    }

    // Creamos un método para resetear la posición de la pelota
    public void Reset()
    {        
        // Asignamos el valor guardado en la variable al transform en el momento que se llame al método
        transform.position = posicionInicial;
        // Reseteamos su transforma al parent
        transform.SetParent(parentTransform);
        // Ponemos enJuego a false para poder volver a comenzar
        enJuego = false;
        // Llamamos al método indicado abajo
        DetenerMovimiento();
    }

    public void DetenerMovimiento()
    {
        // Ponemos el isKinematic a true nuevamente para que la pelota siga a la barra
        rig.isKinematic = true;
        // Ponemos la velocidad del rigidbody a 0 nuevamente.
        // Es lo mismo poner new Vector3(0,0,0)
        rig.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Si no hemos comenzado el juego y el input fire1 está presionado poner enJuego en true.
        // Fire1 por defecto es ctrl izdo y click izdo. Pero el click lo vamos a sacar.
        if (!enJuego && Input.GetButtonDown("Fire1"))
        {
            // Si se da la condición, ponemos en true.
            enJuego = true;
            // Le decimos a la pelota que deje de ser hija de la barra (null = hija de nadie)
            transform.SetParent(null);
            // Ponemos el isKinematic a false para que el movimiento de la pelota se base en la física
            rig.isKinematic = false;
            // Agregamos una fuerza inicial al rigidbody en X e Y en base a la variable expuesta
            rig.AddForce(new Vector3(velocidadInicial, velocidadInicial, 0));
        }
        
    }
}
