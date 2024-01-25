using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoToTarget
{
    Room,
    Kitchen
}

[CreateAssetMenu(fileName = "State", menuName = "States/GoToState")]
public class GoToState : State
{
    [SerializeField] private GoToTarget goToTarget;

    [SerializeField] private float stopDistance;

    
    public override void OnEnter()
    {
        base.OnEnter();
        switch (goToTarget)
        {
            case GoToTarget.Room:
                agent.SetDestination(FindObjectOfType<RoomPoint>().gameObject.transform.position);
                break;
            case GoToTarget.Kitchen:
                agent.SetDestination(FindObjectOfType<KitchenPoint>().gameObject.transform.position);
                break;
        }
    }

    public override void OnTick()
    {
        if (agent.remainingDistance > stopDistance)
            return;

        owner.SetState(nextStateIndex);
    }

    public override void OnExit()
    {
        agent.ResetPath();
    }
}
