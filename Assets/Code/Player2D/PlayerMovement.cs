using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isJumping = false;
    private float moveDirection;
    private bool isGrounded;
    
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    [SerializeField] private float checkRadius;

    private StateManager stateManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //stateManager = GameObject.FindGameObjectWithTag("StateMng").GetComponent<StateManager>();
        stateManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<Transform>().GetChild(0).GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Pause - Resume game...
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (stateManager.GetCurrentState() == EStates.GAMEPLAY)
        {
            ProcessInput();
            Animate();
        }
    }

    private void FixedUpdate()
    {

        if (stateManager.GetCurrentState() == EStates.GAMEPLAY)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
            Move();
        }
    }

    private void PauseGame()
    {
        if(stateManager.GetCurrentState() == EStates.PAUSED)
        {
            stateManager.SetState(EStates.GAMEPLAY);
        }
        else if(stateManager.GetCurrentState() == EStates.GAMEPLAY)
        {
            stateManager.SetState(EStates.PAUSED);
        }

        Debug.Log(stateManager.GetCurrentState());
    }


    private void ProcessInput()
    {
        // Get input
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    private void Animate()
    {
        // Animation
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void Move()
    {
        // Move
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
    }


    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
