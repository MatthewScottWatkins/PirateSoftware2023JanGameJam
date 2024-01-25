using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    public static event Action OnInteract;
    private Controls controls;

    private void OnEnable()
    {
        //StateMachine.OnSendToRoom +=
    }

    private void Start()
    {
        controls = new Controls();

        controls.Player.Interaction.performed += Interaction;
        controls.Enable();
    }

    public void Interaction(InputAction.CallbackContext ctx)
    {
        OnInteract?.Invoke();
    }

}
