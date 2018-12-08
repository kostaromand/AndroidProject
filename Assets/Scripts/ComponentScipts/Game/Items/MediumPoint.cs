using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPoint : Item
{
    Score score;
    float bonusScore = 50f;
    protected override void CollideWithPlayer()
    {
        score.AddScore(bonusScore);
        alive = false;
    }

    void Start()
    {
        itemType = ItemType.MediumPoints;
        score = FindObjectOfType<Score>();
    }
}
