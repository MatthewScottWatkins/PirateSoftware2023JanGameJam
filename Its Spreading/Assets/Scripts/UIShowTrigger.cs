using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class UIShowTrigger : MonoBehaviour, Iinteractable
{
    [SerializeField] private GameObject uiObject;

    public event Action OnShow;
    public event Action OnHide;

    public GameObject GetUIObject() { return uiObject; }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            ShowUI();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            HideUI();
        }
    }

    public void ShowUI()
    {
        uiObject.SetActive(true);
        OnShow?.Invoke();
    }

    public void HideUI()
    { 
        uiObject.SetActive(false);
        OnHide?.Invoke();
    }
}
