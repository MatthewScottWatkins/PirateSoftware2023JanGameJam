using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Station : MonoBehaviour
{
    //refs
    [SerializeField] private GameObject sliderObject;
    [SerializeField] private Image sliderImage;
    private Controls controls;

    [Header("Stats")]
    [SerializeField] private float maxFillAmount;
    [SerializeField] private float fillAmountPerTick;
    private float curFillAmount;
    private bool active = false;
    [HideInInspector] private bool messy = false;

    private bool GetMessy() { return messy; }


    private void Start()
    {
        controls = new Controls();

        controls.Player.Interaction.performed += Interaction;
        controls.Enable();
    }

    public void SetMessy()
    {
        if (messy)
            return;

        messy = true;
        curFillAmount = 0;
    }

    private void Interaction(InputAction.CallbackContext ctx)
    {
        if (!active && !messy)
            return;

        curFillAmount += fillAmountPerTick;
        sliderImage.fillAmount = curFillAmount / maxFillAmount;

        //if is full, turn off
        if(curFillAmount >= maxFillAmount)
        {
            active = false;
            messy = false;
            sliderObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player) && messy)
        {
            active = true;
            sliderObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player) && messy)
        {
            active = false;
            sliderObject.SetActive(false);
        }
    }
}
