using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTransport : MonoBehaviour
{
    public string startAnimatorState;
    public string mainAnimatorState;


    private Animator animator;
    private Transform targetInitParent;
    private GameObject tempTargetObject;


    private void Start()
    {
        //grab the animator component from the current game object
        animator = GetComponent<Animator>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        tempTargetObject = other.gameObject;

        if (!tempTargetObject.CompareTag("Ground"))
        {
            //store the target's original parent
            targetInitParent = tempTargetObject.transform.parent;
            //make the target a child of the trigger game object
            tempTargetObject.transform.SetParent(transform);

            //grab the player movement component from the target game object (player)
            PlayerMovement playerMovement = tempTargetObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                //switch player to flythrough mode (1) / gravity free
                playerMovement.selectedOptionIndex = 1;
                Debug.Log("I just switched to FLYTHROUGH");


                if(animator != null)
                {
                    //play the main animation
                    animator.Play(mainAnimatorState);
                    Debug.Log("I just played the animation: " + mainAnimatorState);

                }


            }
        } 
    }
    


    private void Update()
    {
        //if the main animation finished playing and there is a target game object
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && tempTargetObject != null)
        {
            //reset the parent of the target game object (player) to its original one
            tempTargetObject.transform.SetParent(targetInitParent);
            //reset the animation
            animator.Play(startAnimatorState, -1, 0);
            //grab the player movement component from the target game object (player)
            PlayerMovement playerMovement = tempTargetObject.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                //switch back to character controller mode (0)
                playerMovement.selectedOptionIndex = 0;
                Debug.Log("I just switched to CHARACTER");
            }
            //reset the target object to be nothing
            tempTargetObject = null;

        }
    }
}
