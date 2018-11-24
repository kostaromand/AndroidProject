using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    GameManager gameManager;
    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUpAsButton()
    {
        if (gameManager.Paused == false)
            gameManager.PauseGame();
        else
            gameManager.Resume();
    }
}
