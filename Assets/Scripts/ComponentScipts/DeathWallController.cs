using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallController : MonoBehaviour
{
    public float StartTimer;
    public float increaseSpeedTimer = 5;
    bool timerStoped = false;
    DeathWall wall;
    GameManager gameManager;
    // Use this for initialization
    void Start()
    {
        if(StartTimer==0)
        {
            StartTimer = 5f;
        }
        wall = GetComponent<DeathWall>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerStoped)
            CountTimer();
    }
    private void CountTimer()
    {
        if (StartTimer > 0)
            StartTimer -= Time.deltaTime;
        else
        {
            wall.AllowMove();
            timerStoped = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameManager.GameOver();
        }
    }
}

