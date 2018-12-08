using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Item {
    PlayerController player;
    float startSpeed;
    float duration = 5f;
    float bonusSpeed = 2f;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    protected override void CollideWithPlayer()
    {
        startSpeed = player.speed;
        player.setSpeed(player.speed + bonusSpeed);
        player.gameObject.AddComponent<Timer>().StartTimer(duration, false, () => player.setSpeed(startSpeed));
        alive = false;
    }
}
