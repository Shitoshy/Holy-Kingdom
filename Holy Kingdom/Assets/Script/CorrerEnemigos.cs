using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrerEnemigos : MonoBehaviour
{

    public Transform enemy;

    public float separacion = -1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = new Vector3(personaje.position.x + separacion, transform.position.y, transform.position.z);
        transform.position = new Vector3(enemy.position.x + separacion, 0, 0);
    }
}
