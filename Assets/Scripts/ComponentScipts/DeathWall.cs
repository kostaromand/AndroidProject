using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour {

    public float speed;
    private Vector3 moveVector;
    private bool canMove = false;
	// Use this for initialization
	void Start () {
        speed = speed == 0 ? 0.2f : speed; 
	}

    // Update is called once per frame
    void Update()
    {
        moveVector = new Vector3(speed, 0, 0);
        if (canMove == true)
            Move();
    }

    public void ChangeSpeed(float scale)
    {
        speed += scale;
    }

    public void Move()
    {
        transform.Translate(moveVector * Time.deltaTime);
    }
    public void AllowMove()
    {
        canMove = true;
    }
    public void DenyMove()
    {
        canMove = false;
    }
}
