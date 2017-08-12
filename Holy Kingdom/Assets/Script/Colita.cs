using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Colita : MonoBehaviour
{
    public bool colitaEnBarra;
    private int fuerza = 60;
    private AudioSource disparoColita;
    public AudioClip Throw;
    //bool lanzamiento = false;
	public bool playSound = true;

    void Start()
    {
        colitaEnBarra = true;
        disparoColita = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (colitaEnBarra)
        {
            transform.position = GameObject.Find("GeneradorColitas").transform.position;
            // esta instrucción hará que una colita este siempre en la barra
            if (Input.anyKey)
            {
                colitaEnBarra = false;
            }
        }
        else
        {
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * fuerza);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, fuerza);
			//colitaEnBarra = true;
			if (playSound) {
				disparoColita.PlayOneShot(Throw, 1.0f);
				playSound = false;
			}
            //lanzamiento = true;
        }
    }
}

/*

    Paso 3
    Pegar la colita todo el tiempo al generador
Si usamos el código como lo hemos dejado al final del paso 1, después de 2 segundos de crear una colita con el generador,
esta es abandonada en el sitio en el que fue creada. Para hacer que todo el tiempo la colita acompañe al
gameobject GeneradorColitas, vamos a tener que hacer uso de la clave Find. Generamos un nuevo script para la colita
y en update le decimos que su posicion cambiante va a ser igual a la posición cambiante del gameObject GeneradorColitas
y esto lo hacemos con el siguiente código.

    void Update(){
        transform.position = GameObject.Find("GeneradorColitas").transform.position;
        // esta instrucción hará que una colita este siempre en la barra
    }




    Paso 5 Lógica Lanzar la colita al presionar un boton

Para este paso se me ocurrio hacer una variable boolean que identificara si una colita de burro fue creada en la barra
amarilla y al momento de lanzar, está dejara de ser cierto y la dejara ir, pero resulto que estaba haciendo muy lógica 
demasiado compleja. En vez de eso, sucedio lo siguiente:

Se crean dos variables, una boolean y otra int, llamada colitaEnBarra y fuerza respectivamente:
    private bool colitaEnBarra;
    private int fuerza = 20;
Después, al comienzo de nuestro código, vamos a otorgarle a colitaEnBarra el valor de true.
    void Start()
    {
        colitaEnBarra = true;
    }
En update, vamos a decirle que queremos que nuestra colita siempre este en la posición del gameObject GeneradorColitas
solo si el valor de colitaEnBarra es verdadero, pero si un boton es presionado mientras colitaEnBarra es verdadero, va
a cambiar su valor a falso. ¿Que va a pasar si colitaEnBarra es falso? esto lo podemos definir fácilmente dentro de 
este if, solo le ponemos un else a la instrucción if (colitaEnBarra) para automaticamente lo identifique como 
if (colitaEnBarra = false). Al presionar un boton y convertir a colitaEnBarra en falso, esta abandonara la instrucción
de posicionarse todo el tiempo en el gameobject GeneradorColitas para adquirir una velocidad en línea recta sobre la
posición y

{
    private bool colitaEnBarra;
    private int fuerza = 20;

    void Start(){
        colitaEnBarra = true;
    }

    void Update(){
        if (colitaEnBarra){
            transform.position = GameObject.Find("GeneradorColitas").transform.position;
            // esta instrucción hará que una colita este siempre en la barra
            if (Input.anyKey){
                colitaEnBarra = false;
            }
        }
        else{
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * fuerza);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, fuerza);
        }
    }
}








    Lo que no hay que hacer
                // GetComponent<Rigidbody>().AddForce(new Vector2(0, 1) * fuerza);
            // AddForce(new Vector2(0, 1) * fuerza);
            //transform.AddForce(new Vector2(0, 1) * fuerza);
            // Rigidbody2D.transform.AddForce(new Vector2(0, 1) * fuerza);

*/

