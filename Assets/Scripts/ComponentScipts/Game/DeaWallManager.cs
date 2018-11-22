using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeaWallManager : MonoBehaviour {

    DeathWallController deathWallController;
    Timer startMoveTimer;
    Timer increaseSpeedTimer;
    public float startMoveTime = 5;
    public float incSpeedTime = 5;
    public float incSpeedValue = 0.3f; 
	// Use this for initialization
	void Start () {
        deathWallController = FindObjectOfType<DeathWallController>();
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
