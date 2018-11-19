using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Camera cam;
    float leftSide = 200;
    float rightSide;
    float screenWidth;
    float coorY;
    // Use this for initialization
    void Start()
    {
        screenWidth = Screen.width;
        rightSide = screenWidth - leftSide;
        cam = GetComponent<Camera>();
        coorY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, coorY, transform.position.z);
    }

    public void Attach(Transform obj, Vector3 dir)
    {
        Vector3 pos = cam.WorldToScreenPoint(obj.position);
        if ((pos.x < leftSide && dir.x < 0) || (pos.x > rightSide && dir.x > 0))
            transform.parent = obj;
        else
            transform.parent = null;
    }
}
