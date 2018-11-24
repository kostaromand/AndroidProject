using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text TextField; 
    private float _score;
    public int CurrentScore { get { return Mathf.RoundToInt(_score); } private set { } }
    float scorePerSecond;
    // Use this for initialization
    void Start()
    {
        _score = 0;
        scorePerSecond = 5;
        TextField = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Paused)
        {
            _score += scorePerSecond * Time.deltaTime;
            TextField.text = CurrentScore.ToString();
        }
    }
    public void AddScore()
    {
       
    }
}
