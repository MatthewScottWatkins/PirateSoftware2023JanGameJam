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
    [SerializeField] private Animator animator;
    public string animationText;

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
        if (animatedSprite) 
        {
            
            animator.SetTrigger("Stop"); 
        }

        spriteRenderer.sprite = cleanSprite;
    }

    public void ChangeSpriteMessy()
    {
        if (animatedSprite) 
        { 
            animator.SetTrigger(animationText); 
        }
        else
        {
            spriteRenderer.sprite = messySprite;
        }
        
    }
}
