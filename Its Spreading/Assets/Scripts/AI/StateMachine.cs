using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class StateMachine : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Set in order of seeking, waiting, rage waiting, gotoroom, gotokitchen, kitchen wait")]
    [SerializeField] private State[] states;
    [SerializeField] private Animator animator;
    [SerializeField] private UIShowTrigger uiShow;
    [SerializeField] private ChildHungerManager childHungerManager;
    private CooldownManager cooldownManager;
    private Station targetStation;

    private State curState;

    //behavior bools
    private bool captured;

    //gets/sets
    public Animator GetAnimator() { return animator; }
    public Station GetTargetStation() { return targetStation; }
    public void SetTargetStation(Station newStation) { targetStation = newStation; }
    public ChildHungerManager GetHungerManager() { return childHungerManager; }

    #region events

    public static event Action OnSendToRoom;
    private void OnEnable()
    {
        uiShow.OnShow += SetActive;
        uiShow.OnHide += SetInactive;

        childHungerManager.OnHungerChange += SetHungerVariables;
        KitchenPoint.OnFinishCook += SetGoEat;
    }

    private void OnDisable()
    {
        uiShow.OnShow -= SetActive;
        uiShow.OnHide -= SetInactive;

        childHungerManager.OnHungerChange -= SetHungerVariables;
        KitchenPoint.OnFinishCook -= SetGoEat;
    }

    private void SetActive()
    {
        PlayerInteractor.OnInteract += OnInteract;
    }
    private void SetInactive()
    {
        PlayerInteractor.OnInteract -= OnInteract;
    }

    private void SetGoEat()
    {
        if (!cooldownManager.GetCanCook())
            return;

        cooldownManager.setCanCook(false);
        targetStation.SetClaimed(false);

        curState.OnExit();
        curState = states[5];
        curState.OnEnter();
    }

    private void SetHungerVariables()
    {
        ////on hunger index change, foreach wait state, decrease the time the child waits
        //foreach(State state in states)
        //{
        //    WaitingState wait = state as WaitingState;
        //    if(wait != null)
        //    {
        //        wait.SetWaitIndex(childHungerManager.GetHungerIndex());
        //    }
        //}
    }

    public void SetState(int newStateIndex)
    {
        curState?.OnExit();
        curState = states[newStateIndex];
        curState.OnEnter();
    }

    #endregion

    private void Awake()
    {
        cooldownManager = FindObjectOfType<CooldownManager>();
    }

    private void Start()
    {
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

    private void Update()
    {
        curState?.OnTick();

        //Debug.Log($"{curState}");
    }

    private void OnInteract()
    {
        if (!cooldownManager.GetCanSendToRoom())
            return;

        cooldownManager.SetCanSendToRoom(false);

        //change state(rage wait)
        SetState(2);

        OnSendToRoom?.Invoke();
    }
}
