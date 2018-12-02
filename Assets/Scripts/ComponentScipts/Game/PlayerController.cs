using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    private Player player;
    Camera _camera;
    CameraController cameraController;
    public VirtualJoystick Joystick;
    void Start () {
        player = GetComponent<Player>();
        _camera = Camera.main;
        cameraController = _camera.GetComponent<CameraController>();
    }
	
	// Update is called once per frame
	void Update () {
        var moveVector = getMoveVector();
        transform.position = transform.position + moveVector * Time.deltaTime * player.speed;
        cameraController.Attach(transform, moveVector);
    }

    private Vector3 getMoveVector()
    {
        var dir = new Vector3(Joystick.Horizontal(), Joystick.Vertical());
        return dir;
    }
}
    