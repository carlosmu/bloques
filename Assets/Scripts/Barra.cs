using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{
    // Exponer en el editor una variable para modificar la velocidad
    [SerializeField] private float velocidad = 20f;

    private Vector3 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        // Almacenamos la posición inicial de la barra en una variable Vector3.
        posicionInicial = transform.position;
    }

    // Creamos un método que pueda llamarse desde otros scripts
    // Le tenemos que poner public para que se pueda acceder desde otros scripts
    // Este método lo que hace es sobre escribe el transform position con los valores de posición inicial.
    public void Reset()
    {
        transform.position = posicionInicial;
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la entrada de teclado
        float tecladoHorizontal = Input.GetAxisRaw("Horizontal");
        // Creamos la variable para asignar la posición de la barra
        // Accedemos al transform de la barra, a su posición X y lo sumamos a
        // ..la posición de la barra * la velocidad * el deltaTime, porque la velocidad es por segundos.
        // ..Y el update se ejecuta varias veces por segundo.
        float posX = transform.position.x + (tecladoHorizontal * velocidad * Time.deltaTime);
        // Vamos a definir la nueva posición del transform. A través de un nuevo Vector3. 
        // En la X ponemos nuestra variable. En Y y Z tomamos los valores del transform del objeto. 
        // También podríamos hardcodearlo en: new Vector3(posX, -8, 0) que es lo que hay en la escena.
        // Y le ponemos un Clamp (de Mathf) para que no se salga del -8 y 8 También podríamos hacerlo así:
        // if(posX > 8) posX = 8;
        // if(posX < -8) posX = -8;
        transform.position = new Vector3(Mathf.Clamp(posX, -8, 8), transform.position.y, transform.position.z);        
                        
    }
}
