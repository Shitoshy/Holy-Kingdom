using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Barra : MonoBehaviour {

    public GameObject generador;
    QuitarTutorial llamarScript;

	// Use this for initialization
	void Start () {
        if(llamarScript.pausarJuego)
        {
            gameObject.SetActive(false);
            Debug.Log("Barra activada");
        }

    }
    // Mientras sea falso, no se mueve, cuando sea verdadero, se mueve, anima, elimina al salir de la pantalla y envia al generador un mensaje de hacer una cola nueva


    // Update is called once per frame
    void Update(){
        //   Vector3 rawPosition = ScreenToWorldPoint(0,0);
        if (Input.GetKeyUp(KeyCode.Space))    {
            gameObject.SetActive(true);
        }
        //if (true)
        //{
        //    transform.Translate(new Vector3(0, 0, 1) * Time.deltatime);
        //}   // esto es una idea de como puedes mover objetos, y Time.deltatime es para indicarle que queremos que se mueva metro por segundo y no metros por frame
    }       // tambien podemos usar en vez de new Vector3, vector3.forward como un atajo
}           // transform.Translate(new Vector3(0, 0, 1) * Movespeed * Time.deltatime); public int Movespeed = 5 para agregarle valores adicionles
// De´preferencia usar estas instrucciones en un objeto con rigidbody con la opción kinematic encendida
/*
Para hacer que la colita se mueva y salga disparada puedes usar
Puedes usar activiting GameObject
*/
