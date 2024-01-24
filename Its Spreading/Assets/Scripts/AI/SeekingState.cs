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
        Station attemptStation = FindObjectOfType<StationManager>().GetRandomStation();
        if (attemptStation == null)
            return;
        owner.SetTargetStation(attemptStation);

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
