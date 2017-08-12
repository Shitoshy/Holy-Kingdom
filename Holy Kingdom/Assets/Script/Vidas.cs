using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Vidas : MonoBehaviour
{

    public GameObject corazon;
    public GameObject corazon1;
    public GameObject corazon2;
    private int vidavalue = 1;
    private int vidas;

    void Start()
    {
        vidas = 3;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        vidas -= vidavalue;
        AnimarCorazon();
        if (vidas < 1) {
            SceneManager.LoadScene("Game Over");
        }
    }

    void AnimarCorazon()
    {
        if (vidas == 2)
        {
            iTween.ScaleTo(corazon, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 1f, "easeType", iTween.EaseType.easeOutCirc, "onComplete", "DestruirCorazon"));
        }
        if (vidas == 1)
        {
            iTween.ScaleTo(corazon1, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 1f, "easeType", iTween.EaseType.easeOutCirc, "onComplete", "DestruirCorazon"));
        }
        if (vidas == 0)
        {
            iTween.ScaleTo(corazon2, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 1f, "easeType", iTween.EaseType.easeOutCirc, "onComplete", "DestruirCorazon"));
        }
    }
    void DestruirCorazon()
    {
        if (vidas == 2)
        {
            Destroy(corazon);
        }
        if (vidas == 1)
        {
            Destroy(corazon1);
        }
        if (vidas == 0)
        {
            Destroy(corazon2);
        }

    }


}

/*
Paso 8 Reduciendo corazones
Cree un script llamado Vidas y lo adjunte al Destroyer independiente porque tiene un script destroy que elimina cualquier
objeto que salga fuera de la pantalla, y voy a aprovechar esta función para eliminar también corazones. Empiezo por 
agregar todos los corazones png del GUI al canvas, los acomodo y llamo carazon del 0 al 2, dentro del script llamo
a la librería UI, especifico el gameobject de cada corazon individualmente, voy a necesitar un contador de vidas que
al llegar a cero sea gameover el cuál llamaré vidas, mientras que el valor de cada vida lo definiré como 1 y llamara
vidavalue. En start el valor del contador será de 3 y cada GameObject se le definirá un png. La función OnTriggerEnter2D
dentro del () especifico que activará sus funciones con cualquier colisione que registre el gameobject al que se le
adjuntará este script. Como el valor de vidas comienza con 3, las condiciones será que cuando pierdas una colita, 
elimina un corazon, y así y así hasta que no te quede ninguno.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Vidas : MonoBehaviour {

    public GameObject corazon;
    public GameObject corazon1;
    public GameObject corazon2;
    private int vidavalue = 1;
    private int vidas;

    void Start()
    {
        vidas = 3;
        corazon = GameObject.Find("Corazon");
        corazon1 = GameObject.Find("Corazon1");
        corazon2 = GameObject.Find("Corazon2");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        vidas -= vidavalue;
        if (vidas == 2)
        {
            Destroy(corazon);
        }
        if (vidas == 1)
        {
            Destroy(corazon1);
        }
        if (vidas == 0)
        {
            Destroy(corazon2);
        }
    }
}


*/
