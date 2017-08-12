using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitarTutorial : MonoBehaviour {

    public GameObject tutorialAnimado;
    public bool pausarJuego;
    
	// Use this for initialization
	void Start () {
        pausarJuego = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            pausarJuego = false;
			tutorialAnimado.SetActive (false);
        }
	}
}
