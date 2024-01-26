using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteLayer : MonoBehaviour
{
    SpriteRenderer sprite;

    public int layervalue;
    private void Awake()
    {
        sprite = GetComponentInParent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        sprite.sortingOrder = layervalue;
    }
}
