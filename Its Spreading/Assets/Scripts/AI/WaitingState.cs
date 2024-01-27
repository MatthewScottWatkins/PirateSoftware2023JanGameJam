using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "State", menuName = "States/WaitingState")]
public class WaitingState : State
{
    private RoomPoint roomPoint;

    [SerializeField] private float[] waitLengths;
    [SerializeField] private bool messySetter;
    [SerializeField] private bool eatingWait;
    [SerializeField] private bool roomWait;
    private int waitIndex;

    private float lastWait;

    //public void SetWaitIndex(int val)
    //{
    //    waitIndex = val;
    //}

    public override void OnEnter()
    {
        base.OnEnter();
        lastWait = Time.time;
        owner.GetTargetStation().VFXPlay();
        if (messySetter)
        waitLengths = owner.GetTargetStation().GetMessTimes();

        roomPoint = FindObjectOfType<RoomPoint>();
    }

    public override void OnTick()
    {
        if (roomWait)
            agent.SetDestination(roomPoint.transform.position);

        if (Time.time - lastWait > waitLengths[owner.GetHungerManager().GetHungerIndex()])
        {
            if(messySetter)
                owner.GetTargetStation().SetMessy();
            if (eatingWait)
                owner.GetHungerManager().FillHunger();

            //OnExit();
            owner.SetState(nextStateIndex);
        }
    }

    public override void OnExit()
    {
        owner.GetTargetStation().VFXStop();
    }


}
