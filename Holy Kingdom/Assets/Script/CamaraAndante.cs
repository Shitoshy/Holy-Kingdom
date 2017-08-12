using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraAndante: MonoBehaviour
{

    public Transform camara;

    public float separacion = 0.15f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(camara.position.x + separacion, 0, -10f);
    }
}