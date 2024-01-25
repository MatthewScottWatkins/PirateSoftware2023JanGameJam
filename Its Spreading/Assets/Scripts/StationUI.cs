using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationUI : MonoBehaviour
{
    [SerializeField] private Image messBar;

    private int stationCount;
    private int messyCount;


    private void Start()
    {
        stationCount = FindObjectOfType<StationManager>().GetStationCount();
        Station.OnSetMessy += IncreaseMess;
        Station.OnSetClean += ReduceMess;
    }

    void IncreaseMess()
    {
        messyCount++;
        UpdateUI();
    }

    void ReduceMess()
    {
        messyCount--;
        UpdateUI();
    }

    private void UpdateUI()
    {
        messBar.fillAmount = ((float)messyCount / (float)stationCount);
    }
}
