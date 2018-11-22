using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallController : MonoBehaviour
{
    DeathWall wall;
    GameManager gameManager;
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
        if(wall.speed<4)
        {
            if(wall.speed+ value>4)
            {
                wall.speed = 4;
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

