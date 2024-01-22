using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "States/State")]
public class State : ScriptableObject
{
    protected StateMachine owner;
    [HideInInspector] public NavMeshAgent agent;
    [SerializeField] private State nextState;

    public State Clone(StateMachine newOwner) 
    {
        State clone = Instantiate(this);
        clone.owner = newOwner;
        clone.agent = newOwner.GetComponent<NavMeshAgent>(); 
        return clone;
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnTick()
    {

    }

    public virtual void OnExit()
    {

    }
}
