using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "States/State")]
public class State : ScriptableObject
{
    [SerializeField] private State nextState;
    [SerializeField] protected Optional<string> animationName;
    [HideInInspector] public NavMeshAgent agent;
    protected StateMachine owner;

    public State Clone(StateMachine newOwner) 
    {
        State clone = Instantiate(this);
        clone.owner = newOwner;
        clone.agent = newOwner.GetComponent<NavMeshAgent>();
        return clone;
    }

    public virtual void OnEnter()
    {
        //play anim
        if (animationName.Enabled)
            owner.GetAnimator().Play(animationName.Value);
    }

    public virtual void OnTick()
    {

    }

    public virtual void OnExit()
    {

    }
}
