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
    [SerializeField] private float speed;
    private float curSpeed;
    [SerializeField] private float stoppingDrag;
    [SerializeField] private float stunDuration;
    [SerializeField] private float stunCooldown;
    private float lastStun;
    private float lastCooldown;
    private bool canBeStunned = true;
    private bool stunned = false;
    private bool movementStopped= false;
    private float lastStopped;
    private float stoppedCooldown = 0.3f;

    private void OnEnable()
    {
        KitchenPoint.OnMovementStop += StopMovement;
        Station.OnMovementStop += StopMovement;
        EnvironmentHazard.OnStun += OnStunned;
    }

    private void OnDisable()
    {
        KitchenPoint.OnMovementStop -= StopMovement;
        Station.OnMovementStop -= StopMovement;
        EnvironmentHazard.OnStun -= OnStunned;
    }

    private void StopMovement()
    {
        movementStopped = true;
        lastStopped = Time.time;
        curSpeed = 0;
        rb.velocity = Vector2.zero;
    }


    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controls = new Controls();

        controls.Player.Movement.performed += SetPreviousInput;
        controls.Player.Movement.canceled += SetPreviousInput;
        controls.Enable();

        curSpeed = speed;
    }

    void Update()
    {
        if (previousInput != Vector2.zero)
        {
            rb.AddForce(new Vector2(previousInput.x, previousInput.y) * curSpeed, ForceMode2D.Force);

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

        //movement stopped resets
        if (movementStopped)
        {
            if(Time.time - lastStopped > stoppedCooldown)
            {
                movementStopped = false;
                curSpeed = speed;
            }
        }

        //stunned resets
        if (stunned)
        {
            if (Time.time - lastStun > stunDuration)
            {
                stunned = false;
                lastCooldown = Time.time;
                curSpeed = speed;
            }
        }

        if (!canBeStunned)
        {
            if (Time.time - lastCooldown > stunCooldown)
            {
                canBeStunned = true;
            }
        }
    }

    private void SetPreviousInput(InputAction.CallbackContext ctx)
    {
        previousInput = ctx.ReadValue<Vector2>();
    }

    private void OnStunned()
    {
        if (!canBeStunned || stunned)
            return;
        animator.SetTrigger("Stun");
        canBeStunned = false;
        stunned = true;
        lastStun = Time.time;
        curSpeed = 0;
        rb.velocity = Vector2.zero;
    }
}
