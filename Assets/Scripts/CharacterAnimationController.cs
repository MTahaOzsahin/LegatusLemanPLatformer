using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayJumpingAnim()
    {
        animator.SetBool("isJumping", true);
    }
    public void PlayIdleAnim()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isWalking", false);
    }

    public void PlayRunningAnim()
    {
        animator.SetBool("isRunning", true);
        animator.SetBool("isJumping", false);
    }

    

    public void TriggerAttackAnimation()
    {
        animator.SetTrigger("Attacking");
        
    }
    public void PlayWalkingAnim()
    {
        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
    }
    

    /*
     private Animator animator;
     private void Awake()
     {
         animator = GetComponent<Animator>();       
     }

     public void PlayJumpingAnim()
     {
         animator.SetBool("isJumping", true);
     }
    


     public void TriggerAttackAnimation()
     {
         animator.SetTrigger("Attacking");
     }


     public void PlayIdleAnim()
     {
        // animator.SetBool("isRunning", false);
         animator.SetBool("isJumping", false);
         animator.SetBool("isWalking", false);

     }

     public void PlayRunningAnim()
     {
         animator.SetBool("isRunning", true);
         animator.SetBool("isJumping", false);
     }
     public void StopRunningAnim()
     {
         animator.SetBool("isRunning", false);
     }

     public void PlayWalkingAnim()
     {
         animator.SetBool("isWalking", true);
         animator.SetBool("isRunning", false);
         animator.SetBool("isJumping", false);
     }
     public void StopWalkingAnim()
     {
         animator.SetBool("isWlaking", false);
     }

     */
}
