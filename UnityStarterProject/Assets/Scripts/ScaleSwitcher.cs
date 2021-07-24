using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSwitcher : MonoBehaviour
{
    bool humanScaleActive = false;


    private PlayerMovement playerMovement;
    private Camera playerCamera;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        if(playerMovement)
        {
            if (playerMovement.selectedOptionIndex == 0)
                humanScaleActive = true;

        }
        playerCamera = Camera.main;
    }
    public void SwitchScale()
    {
        if(!humanScaleActive)
        {
            if(playerMovement != null && playerCamera != null)
            {
                playerMovement.selectedOptionIndex = 0;
                playerCamera.fieldOfView = 60f;
            }
        }
        else
        {
            if (playerMovement != null && playerCamera != null)
            {
                playerMovement.selectedOptionIndex = 1;
                playerCamera.fieldOfView = 150f;
            }
        }

        humanScaleActive = !humanScaleActive;
    }



}
