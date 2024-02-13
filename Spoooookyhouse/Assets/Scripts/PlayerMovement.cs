using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEditor.PackageManager;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;//this might not be used if no sprinting in our game
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    //Crouch items
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

 

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    public Transform Body;

    Vector3 moveDirection;

    Rigidbody rb;

    public MeshRenderer viewcone;
    public MeshRenderer viewcone1;

    public bool isSprinting;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
        isSprinting = false;
        startYScale = transform.localScale.y;
        
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, playerHeight * 0.5f + 0.2f, whatIsGround);
        Debug.DrawRay(transform.position, Vector3.down * (playerHeight * 0.5f + 0.2f), Color.red);
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        MyInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            
            Body.transform.localScale = new Vector3(1, .2f, 1);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            moveSpeed = 1;
            viewcone.enabled = true;
            viewcone1.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Body.transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            moveSpeed = 3;
            viewcone.enabled = false;
            viewcone1.enabled = false;
        }
        if (grounded && Input.GetKeyDown(sprintKey))
        {
            isSprinting = true;
            moveSpeed = sprintSpeed;
        }
        if (grounded && Input.GetKeyUp(sprintKey))
        {
            isSprinting = false;
            moveSpeed = walkSpeed;
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}