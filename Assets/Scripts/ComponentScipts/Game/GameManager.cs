using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Paused { get; private set; }
    public Menu menu;
    public PauseButton pauseButton;
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
    public void Exit()
    {

    }
    public void PauseGame()
    {
        Paused = true;
        menu.OpenMenu();
        pauseButton.HideButton();
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Paused = false;
        menu.CloseMenu();
        pauseButton.ShowButton();
        Time.timeScale = 1;
    }
}
