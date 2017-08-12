using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Destroy : MonoBehaviour
{

    GameObject generadorColitas;

    void Start()
    {
        generadorColitas = GameObject.Find("GeneradorColitas");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Aumentar Puntos en 1
        Debug.Log("destroying");
        Destroy(other.gameObject);
        StartCoroutine(generadorColitas.GetComponent<GeneradorColitas>().CrearColitas());
    }

}

/*
    Paso 6 Al eliminar una colita, crear otra
    Para crear otra colita al momento en que la primera es eliminada, primero tengo que crear una referencia al
    GameObject que lo contiene, el cual llame generadorColitas. En Start le pido al código que localice al
    GameObject GeneradorColitas y al momento de que la colisión suceda, después de destruir el objeto, que este
    llame a la función CrearColitas dentro del script GeneradorColitas, como la función empieza como IEnumerator
    tengo quu usar StartCoroutine(nombrede la función()) para llamarla, más la sintaxis correcta para llamar a
    esta función desde otro script es:

        GameObject generadorColitas;

    void Start()
    {
        generadorColitas = GameObject.Find("GeneradorColitas");
    }


    void OnTriggerEnter2D (Collider2D other)
    {
        Destroy(other.gameObject);
        StartCoroutine(generadorColitas.GetComponent<GeneradorColitas>().CrearColitas());
    }

    A diferente de otros nombres de funciones, este va sin "". 
    Activa el código y al destruir una colita, otra se creará.
*/
