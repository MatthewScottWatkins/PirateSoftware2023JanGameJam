using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class StationSpriteChanger : MonoBehaviour
{
    [SerializeField] private Station station;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite cleanSprite;
    [SerializeField] private Sprite messySprite;
    [SerializeField] private bool animatedSprite;

    private void OnEnable()
    {
        station.OnCleaned += ChangeSpriteCleaned;
        station.OnMessy += ChangeSpriteMessy;
    }

    private void OnDisable()
    {
        station.OnCleaned -= ChangeSpriteCleaned;
        station.OnMessy -= ChangeSpriteMessy;
    }

    public void ChangeSpriteCleaned()
    {
        spriteRenderer.sprite = cleanSprite;
        
        //if animated sprite toggle
    }

    public void ChangeSpriteMessy()
    {
        spriteRenderer.sprite = messySprite;

        //if animated sprite toggle
    }
}
