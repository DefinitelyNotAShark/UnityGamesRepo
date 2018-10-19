using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void HighlightShowIcon();//show what button the player needs to press (or give some sort of sign that the thing is interactable)
    void Interact();//do the thing that the button is supposed to do
    void HighlightHideIcon();//hide the icon (when the object is too far away)
}
