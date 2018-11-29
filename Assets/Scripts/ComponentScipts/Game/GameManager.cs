using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool Paused { get; private set; }
    public Menu InGameMenu;
    public PauseButton PauseButton;
    public Score score;
    public Text GameOverScore;
    // Use this for initialization
    void Start()
    {
        setPause(false);
    }

    public void Exit()
    {
        SaveScore();
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
        Debug.Log("Exit");
    }

    void SaveScore()
    {
        float maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        if (maxScore < score.CurrentScore)
            PlayerPrefs.SetInt("MaxScore", score.CurrentScore);
        PlayerPrefs.SetInt("CurrentScore", score.CurrentScore);
    }

    public void PauseGame()
    {
        setPause(true);
        PauseButton.HideButton();
        InGameMenu.OpenMenu();
    }
    public void Resume()
    {
        setPause(false);
        PauseButton.ShowButton();
        InGameMenu.CloseMenu();
    }

    void setPause(bool value)
    {
        if (value == true)
        {
            Paused = true;
            Time.timeScale = 0;
        }
        else
        {
            Paused = false;
            Time.timeScale = 1;
        }
    }
}
