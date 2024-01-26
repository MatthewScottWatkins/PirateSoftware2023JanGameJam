using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EnvironmentHazard : MonoBehaviour
{
    public static Action OnStun;

    public bool stunOn = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player) && stunOn)
        {
            OnStun?.Invoke();
        }
    }

}
