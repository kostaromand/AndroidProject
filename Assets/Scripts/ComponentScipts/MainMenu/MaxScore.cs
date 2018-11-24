using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour {

    Text TextField;
	// Use this for initialization
	void Start () {
        TextField = GetComponent<Text>();
        TextField.text = "Maximal Score: " + PlayerPrefs.GetInt("MaxScore").ToString();
	}
	
}
