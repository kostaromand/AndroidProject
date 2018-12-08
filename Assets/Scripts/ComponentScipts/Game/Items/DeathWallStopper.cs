using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallStopper : Item
{
    DeathWallController wall;
    float duration = 5f;
    void Start()
    {
        itemType = ItemType.WallStopper;
        wall = FindObjectOfType<DeathWallController>();
    }
    protected override void CollideWithPlayer()
    {
        wall.DenyMove();
        wall.gameObject.AddComponent<Timer>().StartTimer(duration, false, () => wall.AllowMove());
        alive = false;
    }
}
