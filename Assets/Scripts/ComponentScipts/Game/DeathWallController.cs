using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallController : MonoBehaviour
{
    GameManager gameManager;
    float maxSpeed = 2.3f;
    public float speed = 0;
    private bool canMove = false;
    // Use this for initialization
    void Start()
    {
        DenyMove();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (canMove)
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

    public void IncreaseSpeed(float value)
    {
        if (speed + value > maxSpeed)
        {
            speed = maxSpeed;
        }
        else
            speed += value;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameManager.Paused == false)
        {
            gameManager.Exit();
        }
    }
}


