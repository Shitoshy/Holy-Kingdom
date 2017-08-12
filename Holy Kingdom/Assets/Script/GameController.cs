using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{

    public Camera cam;
    private float maxWidth;
    private float maxHeight;
    //public GameObject camara = Camera.main;
    //public Transform camara;
    public float separacion = 0.15f;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, -10f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        Vector3 targetHeight = cam.ScreenToWorldPoint(upperCorner);
        float playerHeight = GetComponent<Renderer>().bounds.extents.y;
        maxWidth = targetWidth.x;
        maxHeight = targetHeight.y - (playerHeight - (playerHeight*0.05f));
    }

    void FixedUpdate()
    {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, rawPosition.y, -10.0f);
        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        float targetHeight = Mathf.Clamp(targetPosition.y, -maxHeight, maxHeight);
        targetPosition = new Vector3(targetWidth, targetHeight, targetPosition.z);
        GetComponent<Rigidbody2D>().MovePosition(targetPosition);
    }

    /*void Update()
    {
        //camara.transform.position = new Vector3(camara.transform.position.x + separacion, 0, 0);
        cam.transform.position = new Vector3(cam.transform.position.x + separacion, 0, 0);
    }*/
}
