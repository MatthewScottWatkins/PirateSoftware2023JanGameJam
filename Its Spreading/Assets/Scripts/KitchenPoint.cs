using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class KitchenPoint : MonoBehaviour, IMovementController
{
    [Header("Refs")]
    [SerializeField] private UIShowTrigger uiShow;
    [SerializeField] private Image sliderImage;
    [SerializeField] private Image backgroundSliderImage;
    [SerializeField] private Transform GoToPoint;
    private CooldownManager cooldownManager;

    //stats
    private bool active;
    [SerializeField] private float maxFillAmount;
    [SerializeField] private float fillAmountPerTick;
    private float curFillAmount;

    public static event Action OnFinishCook;
    public static event Action OnMovementStop;

    private void Awake()
    {
        cooldownManager = FindObjectOfType<CooldownManager>();
    }

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

    public Transform GetGoToPoint() { return GoToPoint; }

    private void Interaction()
    {
        if (!active)
            return;

        if (!cooldownManager.GetCanCook())
            return;

        TriggerMovement();

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
            cooldownManager.SetCanCook();
        }

    }

    public void TriggerMovement()
    {
        OnMovementStop?.Invoke();
    }
}
