using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //refs
    private Rigidbody2D rb;
    private Controls controls;
    private SpriteRenderer sprite;
    private Animator animator;
    private Vector2 previousInput;

    [Header("Stats")]
    public float speed;
    public float stoppingDrag;


    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controls = new Controls();

        controls.Player.Movement.performed += SetPreviousInput;
        controls.Player.Movement.canceled += SetPreviousInput;
        controls.Enable();
    }

    void Update()
    {

        if (previousInput != Vector2.zero)
        {
            rb.AddForce(new Vector2(previousInput.x, previousInput.y) * speed, ForceMode2D.Force);

            animator.SetTrigger("Walk");

            //flipping sprite based on input
            if (previousInput.x < 0)
                sprite.flipX = true;
            else if (previousInput.x > 0)
                sprite.flipX = false;

            rb.drag = 1f;
        }
        else
        {
            animator.SetTrigger("Idle");
            rb.drag = stoppingDrag;
        }


    }

    private void SetPreviousInput(InputAction.CallbackContext ctx)
    {
        previousInput = ctx.ReadValue<Vector2>();
    }
}