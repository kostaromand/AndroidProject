using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    private Player player;
    Camera _camera;
    void Start () {
        player = GetComponent<Player>();
        _camera = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButton(0))
        {
            Vector3 ScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 worldPoint = _camera.ScreenToWorldPoint(ScreenPoint);
            player.goToPoint(worldPoint);
        }
    }

}
    