using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rigidBody2D;
    public SpriteRenderer spriteRenderer;

    CharacterMovementController characterMovement;
    CharacterAnimationController characterAnimation;
    CharacterCombat characterCombat;
    Health health;

   

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovementController>();
        characterAnimation = GetComponent<CharacterAnimationController>();
        characterCombat = GetComponent<CharacterCombat>();
        health = GetComponent<Health>();
        rigidBody2D = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        SetCharacterState();

        if (Input.GetKey(KeyCode.K) && 
            characterMovement.movementState != CharacterMovementController.MovementStates.Jumping)
        {
            StartCoroutine(AttackOrder());
        }
      
    }
    private void SetCharacterState()
    {
        if (characterCombat.isAttacking)
            return;
        

        
        if (characterMovement.IsGrounded())
        {
            if (rigidBody2D.velocity.x == 0)
            {
                characterMovement.SetMovementState(CharacterMovementController.MovementStates.Idle);
            }
            else if (rigidBody2D.velocity.x >= 10 | rigidBody2D.velocity.x <= -10)
            {
                characterMovement.SetMovementState(CharacterMovementController.MovementStates.Running);
            }
            else if (rigidBody2D.velocity.x <= 10 | rigidBody2D.velocity.x >= -10)
            {
                characterMovement.SetMovementState(CharacterMovementController.MovementStates.Walking);
            }



        }
       
        else
        {
            characterMovement.SetMovementState(CharacterMovementController.MovementStates.Jumping);
        }

    }

    private IEnumerator AttackOrder()
    {
        
        if (characterCombat.isAttacking)
           
            yield break;
        
        
        
        characterCombat.isAttacking = true;

        characterMovement.movementState = CharacterMovementController.MovementStates.Attacking;
        characterAnimation.TriggerAttackAnimation();


        yield return new WaitForSeconds(0.55f);

        characterCombat.Attack();

        characterCombat.isAttacking = false;


        yield break;



    }

    
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))

        {
            animator.SetBool("isJumping", false);

            isGrounded = true;
        }
       
    }
   
    
    
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))

        {
            animator.SetBool("isJumping", true);
            isGrounded = false;
       }
    }

   */
    /*
         
          animator.SetBool("isRunning", false);

          if (Input.GetKey(KeyCode.D))
          {
              spriteRenderer.flipX = false;
              animator.SetBool("isRunning", true);
              transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
          }

          if (Input.GetKey(KeyCode.A))
          {
              spriteRenderer.flipX = true;
              animator.SetBool("isRunning", true);
              transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
          }

        */

    /*
        Color rayColor;

        if (raycastHit2D.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(spriteRenderer.bounds.center + new Vector3(spriteRenderer.bounds.extents.x, 0),
            Vector2.down * (spriteRenderer.bounds.extents.y + extraHeight), rayColor);
       
        Debug.DrawRay(spriteRenderer.bounds.center + new Vector3(spriteRenderer.bounds.extents.x, 0),
           Vector2.down * (spriteRenderer.bounds.extents.y + extraHeight), rayColor);
       
        Debug.DrawRay(spriteRenderer.bounds.center + new Vector3(0, spriteRenderer.bounds.extents.y),
           Vector2.down * (spriteRenderer.bounds.extents.y + extraHeight), rayColor);
       
        if (raycastHit2D.collider != null)

        Debug.Log("we are colliding with" + raycastHit2D.collider);
*/


    /*
         public enum FacingDirection
      {
          right,
          left,
      }
      public FacingDirection FacingDirection;
      swicht eklenebilir yön için flip kullanarak

      */



}
