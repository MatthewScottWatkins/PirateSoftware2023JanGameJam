using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using UnityEngine.AI;

public class ChildHungerManager : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private Image hungerBar;
    [SerializeField] private NavMeshAgent agent;

    [Header("Stats")]
    [SerializeField] private float maxFillAmount;
    [SerializeField] private float curFillAmount; //serialize for debugging
    [SerializeField] private float fillPerTick;
    [SerializeField] private float tickCooldown;
    private float lastTick;
    [Tooltip("Highest to lowest")]
    [SerializeField] private float[] hungerSegments;
    [SerializeField] private float[] hungerSpeeds;

    private void Start()
    {
        curFillAmount = maxFillAmount;


        //Cooking.onfinishcooking += FillHunger
    }

    private void Update()
    {
        if(Time.time - lastTick > tickCooldown / 60)
        {
            lastTick = Time.time;
            curFillAmount -= fillPerTick;
            UpdateUI();
        }

        if (curFillAmount <= 0)
            curFillAmount = 0;

        agent.speed = hungerSpeeds[GetHungerIndex() ];

    }

    int GetHungerIndex()
    {
        for(int i = 0; i < hungerSegments.Length; i++)
        {
            if(hungerSegments[i + 1] <= 0)
            {
                return i;
            }
            if(curFillAmount < hungerSegments[i] && curFillAmount > hungerSegments[i + 1])
            {
                return i;
            }
        }
        return 0;
    }

    private void UpdateUI()
    {
        hungerBar.fillAmount = curFillAmount / maxFillAmount;
    }

    private void FillHunger()
    {
        curFillAmount = maxFillAmount;
        UpdateUI();
    }
}
