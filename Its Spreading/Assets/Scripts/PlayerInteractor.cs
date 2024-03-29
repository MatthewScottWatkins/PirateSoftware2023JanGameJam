using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{

    public static event Action OnInteract;
    public static event Action OnInteractBaFA;
    public static event Action OnInteractBaFB;
    public static event Action OnRage;
    private Controls controls;
    [SerializeField] private CooldownManager cooldownManager;
    [SerializeField] private Animator anim;

    //stats
    private bool vfxSpawned;
    private float lastvfx;
    private float vfxDuration = 0.5f;

    private void Start()
    {
        controls = new Controls();

        controls.Player.Interaction.performed += Interaction;
        controls.Player.InteractionBaFA.performed += InteractionBaFA;
        controls.Player.InteractionBaFB.performed += InteractionBaFB;
        controls.Player.Rage.performed += Rage;
        controls.Enable();
    }

    private void Update()
    {
        if (!vfxSpawned)
            return;

        if(Time.time - lastvfx > vfxDuration)
        {

        }
    }

    public void Interaction(InputAction.CallbackContext ctx)
    {
        OnInteract?.Invoke();
    }

    public void InteractionBaFA(InputAction.CallbackContext ctx)
    {
        OnInteractBaFA?.Invoke();
    }
    public void InteractionBaFB(InputAction.CallbackContext ctx)
    {
        OnInteractBaFB?.Invoke();
    }

    public void Rage(InputAction.CallbackContext ctx)
    {
        if (cooldownManager.GetCanSendToRoom())
        {
            anim.SetTrigger("Rage");
            OnRage?.Invoke();
        }
    }

}
