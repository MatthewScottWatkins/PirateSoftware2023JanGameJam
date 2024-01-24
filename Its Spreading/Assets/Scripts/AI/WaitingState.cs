using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "State", menuName = "States/WaitingState")]
public class WaitingState : State
{
    [SerializeField] private float[] waitLengths;
    [SerializeField] private bool messySetter;
    private int waitIndex;

    private float lastWait;


    public void SetWaitIndex(int val)
    {
        waitIndex = val;
        Debug.Log(waitIndex);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        lastWait = Time.time;
    }

    public override void OnTick()
    {
        if(Time.time - lastWait > waitLengths[waitIndex])
        {
            if(messySetter)
            owner.GetTargetStation().SetMessy();

            //OnExit();
            owner.SetState(nextStateIndex);
        }
    }

    public override void OnExit()
    {

    }


}
