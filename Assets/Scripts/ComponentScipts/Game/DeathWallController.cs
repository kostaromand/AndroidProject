using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallController : MonoBehaviour
{
    DeathWall wall;
    GameManager gameManager;
    float maxSpeed = 4;
    // Use this for initialization
    void Start()
    {
        wall = GetComponent<DeathWall>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void IncreaseSpeed(float value)
    {
        if(wall.speed< maxSpeed)
        {
            if(wall.speed+ value> maxSpeed)
            {
                wall.speed = maxSpeed;
            }
            else
                wall.IncreaseSpeed(value);
        }
            
    }
    public void allowMove()
    {
        wall.AllowMove();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameManager.GameOver();
        }
    }
}

