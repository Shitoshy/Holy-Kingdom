using UnityEngine;
using System.Collections;

public class MoverObjeto : MonoBehaviour {

    private float velocidad = 10f;
	
	// Update is called once per frame
	void Update () {
        /*Vector3 pos = new Vector3 */
        /*puedo jugar con las layers usando el valor de Z*/
        transform.Translate(new Vector2(1,0) * velocidad * Time.deltaTime);
	}
}
