using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullVision : Item {
    Smoke smoke;
    float duration = 5f;
    private void Start()
    {
        itemType = ItemType.FullVision;
        smoke = FindObjectOfType<Smoke>();
    }
    protected override void CollideWithPlayer()
    {
        smoke.buff++;
        var sprite = smoke.GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        smoke.gameObject.AddComponent<Timer>().StartTimer(duration, false, () =>
        {
            smoke.buff--;
            if (smoke.buff == 0)
                sprite.enabled = true;

        }); 
        alive = false;
    }
}
