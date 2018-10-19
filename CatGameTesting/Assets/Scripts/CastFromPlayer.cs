using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//put this on the player to give it sight!
//this casts the way the player is facing to detect what the player is seeing
//if we see an object with the interact script, we call the interact function

public class CastFromPlayer : MonoBehaviour
{
    [SerializeField]
    private float lineOfSight;//how far can our player see? Mine is set to 1.

    [SerializeField]
    private string interactButtonName;//this is the name of the input axis that causes the player to be able to interact.

    [SerializeField]
    private LayerMask interactMask;//this is the layer that we want to look for objects on. Make a new layer and put interactables on it.

    private RaycastHit2D rayHit;
    private IInteractable interactableInstance;
    

    [HideInInspector]
    public Vector3 direction;//this is set by our move script
	
	void Update ()
    {
        RaycastCheckForObject();
	}

    void RaycastCheckForObject()
    {
        rayHit = Physics2D.Raycast(transform.position, direction, lineOfSight, interactMask);//check for objects on the interactable layer

        if (rayHit.collider != null)
        {
            interactableInstance = rayHit.collider.GetComponent<IInteractable>();//this object is now a var so we can call its script's functions
            if (interactableInstance != null)//if the object we hit is interactable
            {
                interactableInstance.HighlightShowIcon();//now we have the player see that they can interact

                if (Input.GetAxis(interactButtonName) > 0)//if the player chooses to interact
                {
                    interactableInstance.Interact();//now the object does what it is supposed to do
                }
            }
        }
        else
        {
            if(interactableInstance != null)
            interactableInstance.HighlightHideIcon();

        }
        
    }
}
