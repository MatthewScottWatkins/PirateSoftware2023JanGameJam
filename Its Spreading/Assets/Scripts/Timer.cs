using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float maxTime;
    private float timer;

    private StationUI messyBar;

    //probably add event for start
    private void Awake()
    {
        messyBar = FindObjectOfType<StationUI>();
    }

    private void Start()
    {
        timer = maxTime;
        string minutes = Mathf.FloorToInt(timer / 60).ToString();
        if (minutes.Length == 1)
            minutes = $"0{minutes}";
        string seconds = Mathf.FloorToInt(timer % 60).ToString();
        if (seconds.Length == 1)
            seconds = $"0{seconds}";
        timerText.text = $"Time- {minutes} : {seconds}";
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            string minutes = Mathf.FloorToInt(timer / 60).ToString();
            if (minutes.Length == 1)
                minutes = $"0{minutes}";
            string seconds = Mathf.FloorToInt(timer % 60).ToString();
            if (seconds.Length == 1)
                seconds = $"0{seconds}";
            timerText.text = $"Time- {minutes}:{seconds}";
        }
        else
        {
            if (messyBar.statusIndex >= 2)
            {
                //lose
            }
            else
            {
                //win
            }
        }
    }
}
