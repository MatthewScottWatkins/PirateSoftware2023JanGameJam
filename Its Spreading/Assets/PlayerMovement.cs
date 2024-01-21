using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    PlayerInput input;
    PlayerActionInput inputActions;

    public SpriteRenderer sprite;

    public float speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();

        inputActions = new PlayerActionInput();
        inputActions.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();
        float speed = 5f;
        rb.AddForce(new Vector2(inputVector.x, inputVector.y) * speed, ForceMode2D.Force);

        if (inputVector.x == -1)
        {
            sprite.flipX = true;
        }
        else if (inputVector.x == 1)
        { 
            sprite.flipX = false; 
        }
    }
}
