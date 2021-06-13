using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    //raycast stuff
    float raycastMaxDistance = 10f;
    public LayerMask layerMask;

    //hightlight stuff
    [Tooltip("Highlight an interactable object on hover")]
    public bool highlightOnHover = true;
    public Material highlightMaterial;
    private Material originalMaterial, tempMaterial;
    private Renderer render = null;


    void Update()
    {
        RaycastHit hitInfoClick;
        Ray rayClick = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (highlightOnHover)
            HighlightOnHover();

        if (Physics.Raycast(rayClick, out hitInfoClick, raycastMaxDistance, layerMask))
        {

            InteractableObject interactable = hitInfoClick.collider.gameObject.GetComponent<InteractableObject>();

            //if the object has an interactable component 
            if (interactable != null)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    switch (interactable.selectedOptionIndex)
                    {
                        case 0:
                            interactable.SwitchObjectOnOff();
                            break;
                        case 1:
                            interactable.PlayAnimation();
                            break;
                        case 2:
                            interactable.ChangeMaterialColor();
                            break;
                        case 3:
                            interactable.SwitchScene();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    void HighlightOnHover()
    {
        RaycastHit hoverHitInfo;
        Ray hoverRay = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Renderer currentRender;

        if (Physics.Raycast(hoverRay, out hoverHitInfo, raycastMaxDistance, layerMask))
        {
            currentRender = hoverHitInfo.collider.gameObject.GetComponent<Renderer>();

            if (currentRender == render)
                return;

            if (currentRender && currentRender != render)
            {
                if (render)
                {
                    render.sharedMaterial = originalMaterial;
                }

            }

            if (currentRender)
                render = currentRender;
            else
                return;

            originalMaterial = render.sharedMaterial;

            tempMaterial = new Material(originalMaterial);
            render.material = tempMaterial;
            render.material = highlightMaterial;
        }

        else
        {
            if (render)
            {
                render.sharedMaterial = originalMaterial;
                render = null;
            }
        }

    }
}
