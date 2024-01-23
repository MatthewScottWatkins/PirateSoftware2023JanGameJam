using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private State[] states;
    [SerializeField] private Animator animator;
    private Station targetStation;

    private State curState;

    //behavior bools
    private bool captured;

    //gets/sets
    public Animator GetAnimator() { return animator; }
    public Station GetTargetStation() { return targetStation; }
    public void SetTargetStation(Station newStation) { targetStation = newStation; }

    private void Start()
    {
        //events


        //fix navmesh rotations
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        //copy state scriptable object
        for(int i = 0; i < states.Length; i++)
        {
            states[i] = states[i].Clone(this);
        }
        //start on seeking
        SetState(0);
    }

    public void SetState(int newStateIndex) 
    {
        curState = states[newStateIndex];  
        curState.OnEnter(); 
    }

    private void Update()
    {
        curState?.OnTick();

        //Debug.Log($"{curState}");
    }
}
