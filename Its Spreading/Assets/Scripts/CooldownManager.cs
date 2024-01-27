using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : MonoBehaviour
{
    [SerializeField] private float cookCooldown;
    [SerializeField] public float sendToRoomCooldown;
    private bool canCook = false;
    private float lastCook;
    private bool canSendToRoom = false;
    private float lastSendToRoom;

    //gets
    public bool GetCanSendToRoom() { return canSendToRoom; }
    public bool GetCanCook() { return canCook; }
    //sets
    public void SetCanSendToRoom() { canSendToRoom = false; lastSendToRoom = Time.time; }
    public void SetCanCook() { canCook = false; lastCook = Time.time; }

    private void OnEnable()
    {
        StateMachine.OnSendToRoom += SetCanSendToRoom;
        KitchenPoint.OnFinishCook += SetCanCook;
    }

    private void OnDisable()
    {
        StateMachine.OnSendToRoom -= SetCanSendToRoom;
        KitchenPoint.OnFinishCook -= SetCanCook;
    }

    private void Start()
    {
        canCook = true;
    }

    private void Update()
    {
        //reset cook
        if (!canCook)
        {
            if (Time.time - lastCook > cookCooldown)
                canCook = true;
        }

        //reset send to room
        if (!canSendToRoom)
        {
            if(Time.time - lastSendToRoom > sendToRoomCooldown)
                canSendToRoom = true;
        }
    }

}
