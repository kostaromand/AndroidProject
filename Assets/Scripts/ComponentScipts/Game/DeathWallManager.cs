using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallManager : MonoBehaviour {

    DeathWallController deathWallController;
    Timer startMoveTimer;
    Timer increaseSpeedTimer;
    public float startMoveTime = 5;
    public float incSpeedTime = 5;
    public float incSpeedValue = 0.3f; 
	// Use this for initialization
	void Start () {
        deathWallController = FindObjectOfType<DeathWallController>();
        var leftSide = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0));
        deathWallController.transform.position = leftSide -new Vector3(deathWallController.GetComponent<BoxCollider2D>().bounds.size.x / 2, 0,leftSide.z);
        InitiateTimers();
    }

    void InitiateTimers()
    {
        gameObject.AddComponent<Timer>().StartTimer(startMoveTime, false, deathWallController.allowMove);
        Timer.CastedFunction func = () => deathWallController.IncreaseSpeed(incSpeedValue);
        gameObject.AddComponent<Timer>().StartTimer(incSpeedTime, true, func);
    }
	// Update is called once per frame
	void Update () {	
	}
}
