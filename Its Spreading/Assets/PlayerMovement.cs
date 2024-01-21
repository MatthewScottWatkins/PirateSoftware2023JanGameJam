using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    PlayerInput input;
    PlayerActionInput inputActions;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();

        inputActions = new PlayerActionInput;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
