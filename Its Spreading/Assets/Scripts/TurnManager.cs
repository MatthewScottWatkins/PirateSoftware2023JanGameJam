using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TurnManager : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private TMP_Text turnText;

    //events
    public static event Action EndTurn;

    [Header("Stats")]
    [SerializeField] private int maxTurnCount;
    private int turnCount;



    public void OnEndTurnButtonPress()
    {
        //if turnCount != maxTurns
        turnCount++;
        turnText.text = $"Turn: {turnCount.ToString()}";

        EndTurn?.Invoke();
    }
}
