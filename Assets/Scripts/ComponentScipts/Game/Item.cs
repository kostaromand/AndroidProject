using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public ItemType itemType { get; protected set; }
    protected bool alive = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            CollideWithPlayer();
    }
    protected abstract void CollideWithPlayer();
    private void Update()
    {
        if (alive == false)
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);

        }
    }
}
