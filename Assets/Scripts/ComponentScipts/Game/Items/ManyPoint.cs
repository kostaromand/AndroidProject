using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyPoint : Item
{
    Score score;
    float bonusScore = 100f;
    protected override void CollideWithPlayer()
    {
        score.AddScore(bonusScore);
        alive = false;
    }

    void Start()
    {
        itemType = ItemType.ManyPoints;
        score = FindObjectOfType<Score>();
    }
}
