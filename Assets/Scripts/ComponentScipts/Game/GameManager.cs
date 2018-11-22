using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
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
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }
}
