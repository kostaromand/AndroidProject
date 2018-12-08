using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullVision : Item {
    PlayerController player;
    float duration = 5f;
    private void Start()
    {
        itemType = ItemType.FullVision;
        player = FindObjectOfType<PlayerController>();
    }
    protected override void CollideWithPlayer()
    {
        var smoke = player.transform.GetChild(0).gameObject;
        smoke.SetActive(false);
        player.gameObject.AddComponent<Timer>().StartTimer(duration, false, () => smoke.SetActive(true));
        alive = false;
    }
}
