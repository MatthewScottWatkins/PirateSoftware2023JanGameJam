using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class Station : MonoBehaviour
{
    //refs
    [SerializeField] private Image sliderImage;
    [SerializeField] private Image backgroundSliderImage;
    [SerializeField] private UIShowTrigger uiShowTrigger;
    private Controls controls;

    //events
    public static event Action OnSetMessy;
    public static event Action OnSetClean;

    [Header("Stats")]
    [SerializeField] private float maxFillAmount;
    [SerializeField] private float fillAmountPerTick;
    private float curFillAmount;
    private bool active = false;
    private bool messy = false;
    private bool claimed = false;

    //gets
    public bool GetMessyBool() { return messy; }
    public bool GetClaimedBool() { return claimed; }


    private void Start()
    {
        controls = new Controls();

        controls.Player.Interaction.performed += Interaction;
        controls.Enable();
    }

    private void OnEnable()
    {
        uiShowTrigger.OnShow += SetActive;
        uiShowTrigger.OnHide += SetInactive;
    }

    private void SetActive()
    {
        active = true;
        backgroundSliderImage.fillAmount = fillAmountPerTick / maxFillAmount;
    }

    private void SetInactive()
    {
        active = false;
        messy = false;
        claimed = false;
    }

    //sets
    public void SetClaimed()
    {
        claimed = true;
    }

    public void SetMessy()
    {
        if (messy)
            return;

        OnSetMessy?.Invoke();

        //reset variables
        messy = true;
        curFillAmount = 0;
        sliderImage.fillAmount = 0;

        //change sprite to messy sprite
    }

    //using when active
    private void Interaction(InputAction.CallbackContext ctx)
    {
        if (!active && !messy) //change to || when not testing
            return;

        curFillAmount += fillAmountPerTick;
        sliderImage.fillAmount = curFillAmount / maxFillAmount;
        backgroundSliderImage.fillAmount = (curFillAmount + fillAmountPerTick) / maxFillAmount;

        //if full, turn off
        if(curFillAmount >= maxFillAmount)
        {
            OnSetClean?.Invoke(); 
            uiShowTrigger.HideUI();
            //change sprite to clean sprite
        }
    }


}
