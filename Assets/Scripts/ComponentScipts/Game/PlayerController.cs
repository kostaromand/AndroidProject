using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    public float speed;
    Camera _camera;
    CameraController cameraController;
    Rigidbody2D rigidbody;
    public VirtualJoystick Joystick;
    void Start () {
        _camera = Camera.main;
        rigidbody = GetComponent<Rigidbody2D>();
        cameraController = _camera.GetComponent<CameraController>();
    }
	
	// Update is called once per frame
	void Update () {
        var moveVector = getMoveVector() * speed;
        rigidbody.velocity = moveVector;
        cameraController.Attach(transform, moveVector);
    }

    private Vector3 getMoveVector()
    {
        var dir = new Vector3(Joystick.Horizontal(), Joystick.Vertical());
        return dir;
    }
}
    