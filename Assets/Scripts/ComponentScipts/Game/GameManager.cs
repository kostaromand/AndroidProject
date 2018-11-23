using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Paused { get; private set; }
    // Use this for initialization
    void Start()
    {
        Paused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
        Debug.Log("GameOver");
    }
    public void PauseGame()
    {
        Paused = true;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Paused = false;
        Time.timeScale = 1;
    }
}
