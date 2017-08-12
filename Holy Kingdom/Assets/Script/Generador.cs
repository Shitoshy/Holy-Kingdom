using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject[] obj;
    public float tiempoMin = 1.5f;
    public float tiempoMax = 3f;

    void Start()
    {
        Generar();
        //NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
    }

    //void PersonajeEmpiezaACorrer(Notification notificacion)
    //{
    //    Generar();
    //}

    void Generar()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
    }
}
