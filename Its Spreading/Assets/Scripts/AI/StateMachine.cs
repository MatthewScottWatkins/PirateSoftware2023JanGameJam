using System;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Set in order of seeking, waiting, rage waiting, gotoroom, gotokitchen, kitchen wait")]
    [SerializeField] private State[] states;
    [SerializeField] private Animator animator;
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
        PlayerInteractor.OnRage += OnInteract;

        KitchenPoint.OnFinishCook += SetGoEat;
    }

    private void OnDisable()
    {
        PlayerInteractor.OnRage -= OnInteract;

        KitchenPoint.OnFinishCook -= SetGoEat;
    }

    private void SetGoEat()
    {
        targetStation.SetClaimed(false);

        curState.OnExit();
        curState = states[5];
        curState.OnEnter();
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
        Debug.Log("Rage");

        //change state(rage wait)
        SetState(2);

        OnSendToRoom?.Invoke();
    }
}
