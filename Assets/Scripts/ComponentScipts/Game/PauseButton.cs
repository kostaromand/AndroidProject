using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
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
        gameManager.PauseGame();
    }
    public void ShowButton()
    {
        gameObject.SetActive(true);
    }
    public void HideButton()
    {
        gameObject.SetActive(false);
    }
}
