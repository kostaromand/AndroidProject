﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

    // Use this for initialization

    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void ResumeGame()
    {
        gameManager.Resume();
    }
}
