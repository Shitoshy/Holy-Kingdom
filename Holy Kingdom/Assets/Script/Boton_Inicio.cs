using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Boton_Inicio : MonoBehaviour
{
    public void Seleccionar()
    {
        SceneManager.LoadScene("Seleccionar");
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Title");
    }


    public void Intro()
    {
        SceneManager.LoadScene("Intro");
    }
}
