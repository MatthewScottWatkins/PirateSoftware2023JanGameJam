using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "State", menuName = "States/WaitingState")]
public class WaitingState : State
{
    [SerializeField] private float waitLength;

    private float lastWait;

    public override void OnEnter()
    {
        base.OnEnter();
        lastWait = Time.time;
    }

    public override void OnTick()
    {
        if(Time.time - lastWait > waitLength)
        {
            owner.GetTargetStation().SetMessy();// will move to after waiting state
            //OnExit();
            owner.SetState(nextStateIndex);
        }
    }

    public override void OnExit()
    {

    }


}
