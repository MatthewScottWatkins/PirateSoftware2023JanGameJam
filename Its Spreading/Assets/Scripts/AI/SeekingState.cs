using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State",menuName = "States/SeekingState")]
public class SeekingState : State
{
    [SerializeField] private float stopDistance = 2f;
    private Station targetStation;

    public override void OnEnter()
    {
        base.OnEnter();
        owner.SetTargetStation(FindObjectOfType<StationManager>().GetRandomStation()); //will change to random excluded

        targetStation = owner.GetTargetStation();
        targetStation.SetClaimed();
        agent.SetDestination(targetStation.transform.position);
    }

    public override void OnTick()
    {
        if (agent.remainingDistance > stopDistance)
            return;

        //set next state
        owner.SetState(nextStateIndex); //set to waiting state
    }

    public override void OnExit()
    {
        agent.ResetPath();

    }
}
