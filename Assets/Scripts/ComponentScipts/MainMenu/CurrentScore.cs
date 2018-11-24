using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour {

    Text TextField;
    // Use this for initialization
    void Start()
    {
        TextField = GetComponent<Text>();
        TextField.text = "Current Score: " + PlayerPrefs.GetInt("CurrentScore",0).ToString();
    }
}
