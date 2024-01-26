using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StationUI : MonoBehaviour
{
    [SerializeField] private Image messBar;

    public TextMeshProUGUI houseStatusText;
    public string[] houseStatus;
    public int statusIndex;

    public Color[] colourLevels;

    private int stationCount;
    private int messyCount;

    private void OnEnable()
    {
        stationCount = FindObjectOfType<StationManager>().GetStationCount();
        Station.OnSetMessy += IncreaseMess;
        Station.OnSetClean += ReduceMess;
    }

    private void OnDisable()
    {
        stationCount = FindObjectOfType<StationManager>().GetStationCount();
        Station.OnSetMessy -= IncreaseMess;
        Station.OnSetClean -= ReduceMess;
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
        messBar.color = colourLevels[statusIndex];

        if(messBar.fillAmount >= 0 && messBar.fillAmount < 0.2f)
        {
            statusIndex = 0;
        }
        else if(messBar.fillAmount >= 0.2f && messBar.fillAmount < 0.4f)
        {
            statusIndex = 1;
        }
        else if (messBar.fillAmount >= 0.4f && messBar.fillAmount < 0.6f)
        {
            statusIndex = 2;
        }
        else if (messBar.fillAmount >= 0.6f && messBar.fillAmount < 0.8f)
        {
            statusIndex = 3;
        }
        else if (messBar.fillAmount >= 0.8f && messBar.fillAmount < 1)
        {
            statusIndex = 4;
        }

        /*switch (messBar.fillAmount)
        {
            case 0:
                statusIndex = 0;
                    break;

            case  0.2f:
                statusIndex = 1;
                break;
            case > 0.4f:
                statusIndex = 2;
                break;
            case 0.6f:
                statusIndex = 3;
                break;
            case 0.8f:
                statusIndex = 4;
                break;
        }*/

        houseStatusText.color = colourLevels[statusIndex];
        houseStatusText.text = houseStatus[statusIndex];
    }
}
