using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

[DisallowMultipleComponent]

public class EventClick : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerClickHandler
{
    bool active = false;

    Outline outline;
    private void Awake()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!active) 
        {
            active = true;
            transform.DOLocalMoveY(1, 0.5f).SetEase(Ease.InOutSine); 
        }
        else 
        {
            active = false;
            transform.DOLocalMoveY(0, 0.75f).SetEase(Ease.OutBounce); 
        }
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        //empty
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //empty
    }
}
