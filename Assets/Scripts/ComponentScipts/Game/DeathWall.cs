using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour {

    public float speed;
    private Vector3 moveVector;
    private bool canMove = false;
	// Use this for initialization
	void Start () {
        moveVector = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
            Move();
    }

    public void IncreaseSpeed(float value)
    {
        speed += value;
        moveVector = new Vector3(speed, 0, 0);
    }

    public void Move()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
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
