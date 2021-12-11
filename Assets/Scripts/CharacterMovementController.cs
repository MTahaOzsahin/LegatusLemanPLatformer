using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public enum MovementStates
    {
        Idle,
        Running,
        Jumping,
        Attacking,
        Walking,
    }

    [Header("Movement values")]
    public float runningspeed;
    public float walkingspeed;
    public float jumpForce;

    [Header("Raycast lenght and LayerMask")]
    public float isGroundedRayLenght = 0.25f;
    public LayerMask platformLayerMask;

    [Header("Movement State")]
    public MovementStates movementState;

   
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private CharacterAnimationController animController;
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animController = GetComponent<CharacterAnimationController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {

        HandleMovement();
        PlayAnimationsBasedOnState();

    }

    // Update is called once per frame
    void Update()
    {
        HandleJump();       
    }

    /// <summary>
    /// This method handles jumping
    /// </summary>
    private void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {            
            rigidBody2D.velocity = Vector2.up * jumpForce;
        }
        

    }
    

    /// <summary>
    /// This method handles movement
    /// </summary>
    private void HandleMovement()
    {
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;


        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift) && IsGrounded())
            {
                rigidBody2D.velocity = new Vector2(-runningspeed, rigidBody2D.velocity.y);
                transform.eulerAngles = new Vector2(0, 180);
            }
            else

                rigidBody2D.velocity = new Vector2(-walkingspeed, rigidBody2D.velocity.y);
            transform.eulerAngles = new Vector2(0, 180);

        }



        else if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift) && IsGrounded())
            {
                rigidBody2D.velocity = new Vector2(+runningspeed, rigidBody2D.velocity.y);
                transform.eulerAngles = new Vector2(0, 0);
            }
            else

                rigidBody2D.velocity = new Vector2(+walkingspeed, rigidBody2D.velocity.y);
            transform.eulerAngles = new Vector2(0, 0);
        }


        else //No keys pressed
        {
            rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
            rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }



    }


    public bool IsGrounded()
    {

        RaycastHit2D raycastHit2D = Physics2D.BoxCast(spriteRenderer.bounds.center,
            spriteRenderer.bounds.size, 0f, Vector2.down,
            isGroundedRayLenght, platformLayerMask);

        return raycastHit2D.collider != null;
    }

    

    private void PlayAnimationsBasedOnState()
    {
        switch (movementState)
        {
            case MovementStates.Idle:
                animController.PlayIdleAnim();
                break;
            case MovementStates.Running:
                animController.PlayRunningAnim();
                break;
            case MovementStates.Jumping:
                animController.PlayJumpingAnim();
                break;
            case MovementStates.Walking:
                animController.PlayWalkingAnim();
                break;
           case MovementStates.Attacking:
                break;
            default:
                break;
        }
    }

    public void SetMovementState(MovementStates movementStates)
    {
        movementState = movementStates;
        
    }
}
