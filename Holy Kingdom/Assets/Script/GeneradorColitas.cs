using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GeneradorColitas : MonoBehaviour
{

    public Camera cam;
    public GameObject barra;
    public GameObject colita;
    // una referencia para dirigirnos a la barra
    private bool juegoIniciado;
    private bool IrDerecha;
    private bool IrIzquierda;
    private float barraAncho;
    public Colita mycolita;
    public Score burro;
    public GameObject tutorialAnimado;
    public QuitarTutorial scriptTutorial;
	public bool isPlaying = false;

    private float velocidad = 10f;

    void Start()
    {
        //tutorialAnimado = GameObject.Find("Tutorial");
        //scriptTutorial = tutorialAnimado.GetComponent<QuitarTutorial>();
		scriptTutorial = GameObject.Find("GameController").GetComponent<QuitarTutorial>();
		Debug.Log ("Generador");
		float barraAncho = barra.GetComponent<Renderer> ().bounds.extents.x;
		IrIzquierda = false;
		IrDerecha = true;
		//StartCoroutine (CrearColitas ());
    }

	void CheckPlay(){
		if (scriptTutorial.pausarJuego == false && !isPlaying) {
			StartCoroutine (CrearColitas ());
			isPlaying = true;
		}
	}

    public IEnumerator CrearColitas()
    {
		yield return new WaitForSeconds(0.5f);
        if (!burro.estaLlorrando)
        {
            Vector3 generadorPosition = new Vector3(
                transform.position.x,
                transform.position.y,
                0.0f
                );
            Quaternion generadorRotation = Quaternion.identity;
            Instantiate(colita, generadorPosition, generadorRotation);
            //audio.Play();
        }
        // por ahora solo estoy creando una colita
        // mycolita.ToggleControl(true);
    }

    void Update()
    {
		CheckPlay ();

        if (IrDerecha == true)
        {
            transform.Translate(new Vector2(1, 0) * velocidad * Time.deltaTime);
        }
        if (IrIzquierda == true)
        {
            transform.Translate(new Vector2(1, 0) * -velocidad * Time.deltaTime);
        }
        if (transform.position.x >= barra.GetComponent<Renderer>().bounds.extents.x)
        {
            IrDerecha = false;
            IrIzquierda = true;
        }
        if (transform.position.x <= -barra.GetComponent<Renderer>().bounds.extents.x)
        {
            IrIzquierda = false;
            IrDerecha = true;
        }
    }
}


/*
 Paso 1 Midiendo los límites de la barra
  
 Para descubrir lo largo de la barra, creo primero un gameObject para hacer referencia a la barra, y después
 de especificar que el juego haga a mi camara como la única que existe, quiero que guarde dentro de una nueva
 variable llamada barraAncho lo que mida mi gameObject barra a lo ancho. Después medimos los que mida a lo 
 ancho mi gameobject generadorColitas, como es el objeto al que se le adjunta este script, no es necesario 
 hacerle referencia al mencionar el GetComponent. Por ultimo obtenemos la distancia máxima que usaremos para el
 desplace del generador de colita restando el cancho de la barra menos el ancho del generador.

    public Camera cam;
    public GameObject barra;
    private float maxWidth;
    // esta define el punto maximo en en que colita puede desplazarse

    void Start () {
        if (cam == null){
            cam = Camera.main;
        }
        float barraAncho = barra.GetComponent<Renderer>().bounds.extents.x;
        float generadorAncho = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = barraAncho - generadorAncho;
    }

  */

/*
 * Paso 2
Hacer aparecer un colita en el generador
Lo primero que hicimos fue crear un objeto vacio y lo llamamos generadorColitas. Como lo que queremos es que las 
colitas aparezcan al centro de mi generador, escribimos primero una referencia a nuestro generador. Después de 
definir las dimensiones de la barra, maxWidth se encargará de representar el área en que se podrá mover nuestra
colita, en nuestro caso, queremos lanzar colas de burro, así que creamos un nuevo gameObject y lo llamamos colita;

Ahora, queremos que nuestras colitas aparezcan en la pantalla, y para ello necesitamos crear un sistema de rutinas,
o mejor dicho un loop. Empezamos escribiendo IEnumerator y la vamos a llamar Crearcolitas y que es lo que queremos 
que haga? queremos que Instantiate/Creadora haga aparecer nuestra colita, y si lo recuerdan , la clave Instantiate 
necesita un objeto, posición, y rotación. Así que vamos a inventar que a la posición de la colita la llamamos 
generadorPosition y generadorRotation.
    
    IEnumerator Crearcolitas()
    {
        Instantiate(colita, generadorPosition, generadorRotation);
    }

Ahora vamos a definirle de que se trata esta generadorPosition, para facilidad del código vamos a tomar el gameObject,
vacio dentro nuestro de editor de Unity y colocarlo en alguna parte de la escena que nos ayude, en este caso, en
la parte superior por fuera de la pantalla, volvemos al script y ahora le vamos agregar nuevas instrucciones a 
nuestro código. 
Nuestro generadorPosition va a ser Vector3 (porque el editor de Unity sigue siendo X,Y,Z) y los valores de este será
un nuevo Vector3 con sus valores x,y,z 


    IEnumerator CrearColitas(){
        Vector3 generadorPosition = new Vector3(
            x,
            y,
            z);
        Instantiate(colita, generadorPosition, generadorRotation);
    }

Ahora ¿que valores tendrá cada uno? 
Necesitamos que x sea el punto 0 del generador, y como este es el objeto que tiene adjunto este script simplemente
ponemos 0, lo mismo pasa sus valores y z.   

    IEnumerator CrearColitas(){
        Vector3 generadorPosition = new Vector3(
             transform.position.x,
             transform.position.y,
            0.0f);
        Instantiate(colita, generadorPosition, generadorRotation);
    }

Ahora vamos a definir la ratonación de nuestro objeto al aparecer, el cuál no queremos que tenga ningún valor, 
y para definir la rotación usamos Quaternion. Vamos a definir la spawnRotation con Quaternion como Quaternion.identity
para indicar que tal cual como esta el objeto así va a aparecer, sin ningún giro.

    IEnumerator CrearColitas(){
        Vector3 generadorPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            0.0f);
        Quaternion generadorRotation = Quaternion.identity;
        Instantiate(colita, generadorPosition, generadorRotation);
    }

Si lo dejaramos así, el código me reporta que no todas las claves ofrecen un valor, así que para que funcione el
código, agregue un yield return new WaitForSeconds(2.0f); de modo que pasando dos segundos, se crea la primera 
colita.

    IEnumerator CrearColitas(){
        yield return new WaitForSeconds(2.0f);
            Vector3 generadorPosition = new Vector3(
                transform.position.x,
                transform.position.y,
                0.0f
                );
            Quaternion generadorRotation = Quaternion.identity;
            Instantiate(colita, generadorPosition, generadorRotation);
            // por ahora solo estoy creando una colita

    }

Activa el juego y ahora, después de dos segundos, se crea la primera colita

        public class GeneradorColitas : MonoBehaviour {

            public Camera cam;
            public GameObject barra;
            public GameObject colita;
            private bool juegoIniciado;

            private float velocidad = 10f;

            void Start () {
                if (cam == null){
                    cam = Camera.main;
                }
                float barraAncho = barra.GetComponent<Renderer>().bounds.extents.x;
                StartCoroutine(CrearColitas());
            }

            IEnumerator CrearColitas(){
                yield return new WaitForSeconds(2.0f);
                    Vector3 generadorPosition = new Vector3(
                        transform.position.x,
                        transform.position.y,
                        0.0f
                        );
                    Quaternion generadorRotation = Quaternion.identity;
                    Instantiate(colita, generadorPosition, generadorRotation);
            }

            void Update () {
                transform.Translate(new Vector2(1, 0) * velocidad * Time.deltaTime);
            }
        }



    Paso 4 Hacer que el generador de colitas vaya y vuelva según el tamaño de la barra
Para este paso, quiero que mi generador de colitas se mueva de lado a lado, alcanzando el extremo final de la barra
amarilla y que regrese cuando lo toque. Para ello cree dos valores booleans llamados IrDerecha e IrIzquierda, así como
una velocidad standard de mi gameobject colita de 10 unidades. Después, en la función de Update, quiero aclarar que
cada vez que la función boolean de IrDerecha sea cierta, el generador ira a la derecha, y al momento en que esta toque
el extremo derecho, cambiara su valor de IrDerecha a falso y activará el valor de IrIzquierda, el proceso se repite 
y una vez terminado, que al comienzo del juego los valores de Irderecha sea verdadero y el de IrIzquierda sea falso.

using UnityEngine;
using System.Collections;

public class GeneradorColitas : MonoBehaviour {

    public Camera cam;
    public GameObject barra;
    public GameObject colita;
    // una referencia para dirigirnos a la barra
    private bool juegoIniciado;
    private bool IrDerecha;
    private bool IrIzquierda;
    private float barraAncho;

    private float velocidad = 10f;

    void Start () {
        float barraAncho = barra.GetComponent<Renderer>().bounds.extents.x;
        IrIzquierda = false;
        IrDerecha = true;
        StartCoroutine(CrearColitas());
    }

    IEnumerator CrearColitas()
    {
        yield return new WaitForSeconds(2.0f);
        Vector3 generadorPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            0.0f
            );
        Quaternion generadorRotation = Quaternion.identity;
        Instantiate(colita, generadorPosition, generadorRotation);
        // por ahora solo estoy creando una colita
    }

    void Update() {
        if (IrDerecha == true)
        {
            transform.Translate(new Vector2(1, 0) * velocidad * Time.deltaTime);
        }
        if (IrIzquierda == true)
        {
            transform.Translate(new Vector2(1, 0) * -velocidad * Time.deltaTime);
        }
        if (transform.position.x >= barra.GetComponent<Renderer>().bounds.extents.x)
        {
            IrDerecha = false;
            IrIzquierda = true;
        }
        if (transform.position.x <= -barra.GetComponent<Renderer>().bounds.extents.x)
        {
            IrIzquierda = false;
            IrDerecha = true;
        }
    }
}



    */
