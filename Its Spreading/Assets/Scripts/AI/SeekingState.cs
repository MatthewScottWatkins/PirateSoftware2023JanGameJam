using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State",menuName = "States/SeekingState")]
public class SeekingState : State
{
    [SerializeField] private float stopRange = 2f;
    private Station targetStation;

    public override void OnEnter()
    {
        targetStation = FindObjectOfType<StationManager>().GetRandomStation(); //will change to random excluded
        targetStation.SetClaimed();
        agent.SetDestination(targetStation.transform.position);
    }

    public override void OnTick()
    {
        if ((agent.transform.position - targetStation.transform.position).sqrMagnitude > stopRange * stopRange)
            return;

        targetStation.SetMessy();// will move to after waiting state
        OnExit();

    }

    public override void OnExit()
    {
        agent.ResetPath();
        owner.SetState(1); //set to waiting state
    }
}
