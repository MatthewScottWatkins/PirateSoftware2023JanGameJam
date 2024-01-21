using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    //refs
    private Controls controls;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    [Header("Stats")]
    public float movementSpeed;

    //movement
    private Vector2 previousInput;


    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        controls = new Controls();

        controls.Player.Movement.performed += SetPreviousInput;
        controls.Player.Movement.canceled += SetPreviousInput;
        controls.Enable();
    }

    public void SetPreviousInput(InputAction.CallbackContext ctx)
    {
        previousInput = ctx.ReadValue<Vector2>();
    }

    public void Update()
    {
        Vector2 force = Vector2.zero;

        if(previousInput != Vector2.zero)
        {
            //sprite flipping
            if (previousInput.x != 0)
                sprite.flipX = true;
            else
                sprite.flipX = false;

            force += new Vector2(previousInput.x, previousInput.y) * movementSpeed * Time.deltaTime;
        }
        rb.velocity = force;
        //rb.AddForce(force, ForceMode2D.Impulse);
    }
}
