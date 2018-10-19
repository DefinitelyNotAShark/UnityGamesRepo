using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is an example of a script that would be on an interactable object.
//it requires an icon (which on mine is just a circle sprite) and it makes the circle appear when the player gets close and change color
//when they press the button that is set up to be the interact button
//It implements the interface Iinteractable, and won't do anything unless the interface exists and the player has the raycast script on them
//input also needs to be set up for the interact button.
public class InteractExample : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject buttonIcon;

    private void Start()
    {
        buttonIcon.gameObject.SetActive(false);
    }

    public void HighlightHideIcon()
    {
        buttonIcon.gameObject.SetActive(false);
    }

    public void HighlightShowIcon()
    {
        buttonIcon.GetComponent<SpriteRenderer>().color = Color.yellow;
        buttonIcon.gameObject.SetActive(true);
    }

    public void Interact()
    {
        buttonIcon.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
