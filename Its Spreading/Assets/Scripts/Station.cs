using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public enum StationGameType
{
    Spam,
    BackandForth
}

public class Station : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private Image sliderImage;
    [SerializeField] private Image backgroundSliderImage;
    [SerializeField] private UIShowTrigger uiShowTrigger;
    private Controls controls;

    //events
    public static event Action OnSetMessy;
    public static event Action OnSetClean;
    public event Action OnCleaned;
    public event Action OnMessy;

    [Header("Stats")]
    public StationGameType gameType;
    [SerializeField] private float maxFillAmount;
    [SerializeField] private float fillAmountPerTick;
    [SerializeField] private float[] messTimes;
    private float curFillAmount;
    private bool active = false;
    [SerializeField] private bool messy = false;
    private bool claimed = false;
    private bool curAction = false;

    //gets
    public bool GetMessyBool() { return messy; }
    public bool GetClaimedBool() { return claimed; }
    public float[] GetMessTimes() { return messTimes; }

    #region events
    private void OnEnable()
    {
        uiShowTrigger.OnShow += SetActive;
        uiShowTrigger.OnHide += SetInactive;
    }

    private void OnDisable()
    {
        uiShowTrigger.OnShow -= SetActive;
        uiShowTrigger.OnHide -= SetInactive;
    }

    private void SetActive()
    {
        if (!messy)
        {
            uiShowTrigger.GetUIObject().SetActive(false);
            return;
        }
        active = true;
        backgroundSliderImage.fillAmount = fillAmountPerTick / maxFillAmount;
        if(gameType == StationGameType.Spam)
        {
            PlayerInteractor.OnInteract += InteractionSpam;
        }
        if(gameType == StationGameType.BackandForth)
        {
            PlayerInteractor.OnInteractBaFA += InteractionBaFA;
            PlayerInteractor.OnInteractBaFB += InteractiveBaFB;
        }

    }

    private void SetInactive()
    {
        active = false;

        if (gameType == StationGameType.Spam)
        {
            PlayerInteractor.OnInteract -= InteractionSpam;
        }
        if (gameType == StationGameType.BackandForth)
        {
            PlayerInteractor.OnInteractBaFA -= InteractionBaFA;
            PlayerInteractor.OnInteractBaFB -= InteractiveBaFB;
        }
    }
    #endregion

    //sets
    public void SetClaimed(bool val)
    {
        claimed = val;
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


        if(TryGetComponent<EnvironmentHazard>(out EnvironmentHazard hazard))
        {
            hazard.enabled = true;
        }

        //change sprite to messy sprite

    }

    //using when active
    private void InteractionSpam()
    {
        if (!active ||!messy)
            return;

        curFillAmount += fillAmountPerTick;
        sliderImage.fillAmount = curFillAmount / maxFillAmount;
        backgroundSliderImage.fillAmount = (curFillAmount + fillAmountPerTick) / maxFillAmount;

        //if full, turn off
        if(curFillAmount >= maxFillAmount)
        {
            messy = false;
            claimed = false;
            curFillAmount = 0;
            sliderImage.fillAmount = 0;
            backgroundSliderImage.fillAmount = fillAmountPerTick;
            OnSetClean?.Invoke(); 
            OnCleaned?.Invoke();
            uiShowTrigger.HideUI();

            if (TryGetComponent<EnvironmentHazard>(out EnvironmentHazard hazard))
            {
                hazard.enabled = true;
            }
            //change sprite to clean sprite
        }
    }

    private void InteractionBaFA()
    {
        if (!active || !messy)
            return;

        //if Button B is press instead of button A return;
        if (curAction == false)
            return;

        curAction = false;

        curFillAmount += fillAmountPerTick;
        sliderImage.fillAmount = curFillAmount / maxFillAmount;
        backgroundSliderImage.fillAmount = (curFillAmount + fillAmountPerTick) / maxFillAmount;

        //if full, turn off
        if (curFillAmount >= maxFillAmount)
        {
            messy = false;
            claimed = false;
            curFillAmount = 0;
            sliderImage.fillAmount = 0;
            backgroundSliderImage.fillAmount = fillAmountPerTick;
            OnSetClean?.Invoke();
            OnCleaned?.Invoke();
            uiShowTrigger.HideUI();

            if (TryGetComponent<EnvironmentHazard>(out EnvironmentHazard hazard))
            {
                hazard.enabled = true;
            }  
        }
    }

    private void InteractiveBaFB()
    {
        if (!active || !messy)
            return;

        //if Button A is press instead of button B return;
        if (curAction == true)
        {
            return;
        }

        curAction = true;

        curFillAmount += fillAmountPerTick;
        sliderImage.fillAmount = curFillAmount / maxFillAmount;
        backgroundSliderImage.fillAmount = (curFillAmount + fillAmountPerTick) / maxFillAmount;

        //if full, turn off
        if (curFillAmount >= maxFillAmount)
        {
            messy = false;
            claimed = false;
            curFillAmount = 0;
            sliderImage.fillAmount = 0;
            backgroundSliderImage.fillAmount = fillAmountPerTick;
            OnSetClean?.Invoke();
            OnCleaned?.Invoke();
            uiShowTrigger.HideUI();

            if (TryGetComponent<EnvironmentHazard>(out EnvironmentHazard hazard))
            {
                hazard.enabled = true;
            }
        }
    }


}
