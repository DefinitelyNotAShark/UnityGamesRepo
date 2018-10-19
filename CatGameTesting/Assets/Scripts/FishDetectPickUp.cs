using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This goes on the fish prefab.
//doesn't need to be in the scene

public class FishDetectPickUp : MonoBehaviour
{
    [SerializeField]
    private string interactButton;//name of button we press to fish as set up on input axis

    private PlayerStateManager stateManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("THE FISH COLLIDER HAS BEEN TRIGGERED");
        collision.GetComponentInChildren<ImageActive>().TurnImageOn();

        stateManager = collision.gameObject.GetComponent<PlayerStateManager>();//get state manager
        stateManager.canDropFish = false;//cant drop a fish while picking up a fish
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxis(interactButton) > 0)//when you press the button to pick up fish
        {
            StartCoroutine(pickUpFishBuffer(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponentInChildren<ImageActive>().TurnImageOff();//this is how we hide the icon
    }

    IEnumerator pickUpFishBuffer(Collider2D collision)//this is to make it so that player doesn't immediately drop fish after picking one up
    {
        stateManager.canDropFish = false;//make it so the pickup button doesn't drop it
        stateManager.playerHasFish = true;//we have fish now
        collision.GetComponentInChildren<ImageActive>().TurnImageOff();//this is how we hide the icon
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);//set object invisible   
        
        yield return new WaitForSeconds(2);
        stateManager.canDropFish = true;//make it so we can drop the fish that we just picked up
        Destroy(this.gameObject);
    }
}

