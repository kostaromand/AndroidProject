using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Item {
    PlayerController player;
    float duration = 5f;
    float bonusSpeed = 2f;
    private void Start()
    {
        itemType = ItemType.SpeedBust;
        player = FindObjectOfType<PlayerController>();
    }
    protected override void CollideWithPlayer()
    {
        player.ChangeSpeed(bonusSpeed);
        player.gameObject.AddComponent<Timer>().StartTimer(duration, false, () => player.ChangeSpeed(-bonusSpeed));
        alive = false;
    }
}
