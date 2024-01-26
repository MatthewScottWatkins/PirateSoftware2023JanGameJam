using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    public static event Action OnInteract;
    public static event Action OnRage;
    private Controls controls;

    private void OnEnable()
    {
        //StateMachine.OnSendToRoom +=
    }

    private void Start()
    {
        controls = new Controls();

        controls.Player.Interaction.performed += Interaction;
        controls.Player.Rage.performed += Rage;
        controls.Enable();
    }

    public void Interaction(InputAction.CallbackContext ctx)
    {
        OnInteract?.Invoke();
    }
    public void Rage(InputAction.CallbackContext ctx)
    {
        OnRage?.Invoke();
    }

}
