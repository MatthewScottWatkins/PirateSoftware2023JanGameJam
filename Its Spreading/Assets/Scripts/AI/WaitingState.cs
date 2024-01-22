using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "States/WaitingState")]
public class WaitingState : State
{
    [SerializeField] private float waitLength;

    private float lastWait;

    public override void OnEnter()
    {
        lastWait = Time.time;
        //play anim
    }

    public override void OnTick()
    {
        if(Time.time - lastWait > waitLength)
        {

            OnExit();
        }
    }

    public override void OnExit()
    {
        //owner.SetState();
    }


}
