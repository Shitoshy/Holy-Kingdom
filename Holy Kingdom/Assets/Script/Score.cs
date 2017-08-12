using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{

    public Text puntosText;
    public int colitaValue;
    private int puntos;
    public Animator animator;
    public bool estaLlorrando;
    public GeneradorColitas gc;
    private float dancingSpeed;
    private AudioSource llanto;
    public AudioClip sonidoburro;
    public GameObject tutorialAnimado;
    public QuitarTutorial scriptTutorial;

    // Use this for initialization
    void Start()
    {
        //tutorialAnimado = GameObject.Find("Tutorial");
        //scriptTutorial = tutorialAnimado.GetComponent<QuitarTutorial>();
		scriptTutorial = GameObject.Find("GameController").GetComponent<QuitarTutorial>();
		if (scriptTutorial.pausarJuego == false) {
			puntos = 0;
			estaLlorrando = false;
            FixedUpdate();
			dancingSpeed = 0.8f;
			animator.speed = dancingSpeed;
		} else {
			dancingSpeed = 0f;
			animator.speed = dancingSpeed;
		}

		//Obtener el audio source para usarlo después
		llanto = GetComponent<AudioSource>();
    }

	void Update(){
		if (scriptTutorial.pausarJuego == false) {
			//puntos = 0;
			estaLlorrando = false;
            FixedUpdate();
			dancingSpeed = 0.8f;
			animator.speed = dancingSpeed;
		} else {
			dancingSpeed = 0f;
			animator.speed = dancingSpeed;
		}
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("colita"))
        {
            //animar si la colita toca el collider, siempre y la colita no este en la barra

            if (!coll.GetComponent<Colita>().colitaEnBarra)
            {
                Destroy(coll.gameObject);
                AnimarDolor();
                llanto.PlayOneShot(sonidoburro, 50.0f);
                puntos += colitaValue;
                FixedUpdate();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        puntosText.text = "Puntos:\n" + puntos;
        if (PlayerPrefs.GetInt("Player Score") < puntos)
        {
            PlayerPrefs.SetInt("Player Score", puntos);
        }
        if (puntos % 5 == 0)
        {
            dancingSpeed = dancingSpeed < 2.5f ? dancingSpeed += .1f : 2.5f;
        }
    }

    public void AnimarDolor()
    {
        estaLlorrando = !animator.GetBool("adolorido");
        OcultarBarra();
        animator.SetBool("adolorido", !animator.GetBool("adolorido"));
        animator.speed = estaLlorrando ? 1 : dancingSpeed;
    }

    public void OcultarBarra()
    {
        GameObject.FindGameObjectWithTag("Barra").GetComponent<Renderer>().enabled = !estaLlorrando;
        if (!estaLlorrando)
        {
            StartCoroutine(gc.CrearColitas());
        }
    }
}

/*
    Paso 7 Programar un Score
El destroyer es el encargado de registrar los puntos que lleva el jugador, así que vamos a crear un nuevo script 
component llamada Score, y de una vez creamos el text object que tendra por nombre PuntosText, lo alineamos en 
la esquina superior izquierda, le ponemos dentro de su ventanilla Puntos: 0, y todo lo demás. dentro del script creamos 
el public Text puntosText y la libreria para textos, y también necesitaremos una public int colitaValue porque necesitamos 
un integrer que represente el valor de un punto. Después creamos una private int llamado puntos el cuál contendrá
la cantidad total de puntos recolectados. Lo que queremos es que en Start() queremos que el valor de score sea = 0, 
después definimos que scoreText.text es igual a "Puntos\n" + puntos; (el \n creo que sirve para definir que a partir 
de este punto todo lo que le sigue será sustituido por un valor/variable u otros). Mejor movemos este código a su 
propia funcion llamada UpdateScore y en Start dejamos la clave para iniciar esta funcion.

    public Text puntosText;
    public int colitaValue;
    private int puntos;

	void Start () {
        puntos = 0;
        UpdateScore();
    }

	void UpdateScore()
    {
        puntosText.text = "Puntos\n" + puntos;
    }

Nuestro burro ya tiene el componente Destroy, el cual tiene la instrucción que cuando un objeto 2D colisione, 
destruya el objeto que collisiono con él, algo parecido vamos a hacer para sumar los puntos. Vamos a inventar una 
instrucción void OnTriggerEnter2d y lo que hará es que cuando se active el score se incrementara el valor de 
colitaValue; y le ponemos la clave para llamar a la función UpdateScore(); de vuelta en el editor arrastramos el objeto
PuntosText en la ventanilla text de nuestro burro, y el valor de colitaValue (es decir, cuantos puntos vale cada colita
anotada) será de 1.

void OnTriggerEnter2D ()
{
    puntos += colitaValue;
    UpdateScore();
}

Ahora, ¿como le decimos al juego que el collider que queremos que cuente es el que pusimos en el trasero de nuestro
burro? de vuelta al GUI/editor de Unity, selecciona al burro que contiene el destroyer.
Si abres su script notaras que en su nombre OnTriggerEnter2 entre los parentesis tiene una condición llamada
(Collider2D other), lo que significa que cualquier objeto 2D que colisione con el, activara este evento. Lo mismo
haremos dentro de nuestro script Score, en OnTriggerEnter2D escribimos dentro de los () Collider2D other
para que cualquier cosa que colisione con el trasero cuente como un punto (este paso no sucede en el juego catch game
porque la funcion sucede en un solo script y aqui estamos trabajando con dos), y si te preguntabas porque la operación
funciona solo si se colisiona con el destroyer del trasero y no con el destroyer de afuera es porque nuestro burro
carga con dos scripts: uno llamada Destroyer y otro llamado Score, con (Collider2D other) busca si el GameObject 
tiene un collider que registre que otros gameobjects interactuen con él y este lo toma como el collider al cuál le 
sumara puntos, a diferencia del destroyer que solo elimina y bajará puntos que esta independiente y es su propio
gameobject.

Con esto, al empezar a jugar, el juego contara puntos cada vez que logres meter una colita en su trasero.
     */
