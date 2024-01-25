using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class KitchenPoint : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private UIShowTrigger uiShow;
    [SerializeField] private Image sliderImage;
    [SerializeField] private Image backgroundSliderImage;

    //stats
    private bool active;
    [SerializeField] private float maxFillAmount;
    [SerializeField] private float fillAmountPerTick;
    private float curFillAmount;

    public static event Action OnFinishCook;

    #region events
    private void OnEnable()
    {
        uiShow.OnShow += SetActive;
        uiShow.OnHide += SetInactive;
    }

    private void OnDisable()
    {
        uiShow.OnShow -= SetActive;
        uiShow.OnHide -= SetInactive;
    }

    private void SetActive()
    {
        active = true;
        PlayerInteractor.OnInteract += Interaction;
    }

    private void SetInactive()
    {
        active = false;
        PlayerInteractor.OnInteract -= Interaction;
    }
    #endregion

    private void Interaction()
    {
        if (!active)
            return;

        curFillAmount += fillAmountPerTick;
        sliderImage.fillAmount = curFillAmount / maxFillAmount;
        backgroundSliderImage.fillAmount = (curFillAmount + fillAmountPerTick) / maxFillAmount;

        //if full, turn off
        if (curFillAmount >= maxFillAmount)
        {
            curFillAmount = 0;
            sliderImage.fillAmount = 0;
            backgroundSliderImage.fillAmount = fillAmountPerTick;
            OnFinishCook?.Invoke();
            uiShow.HideUI();
        }

    }

}
