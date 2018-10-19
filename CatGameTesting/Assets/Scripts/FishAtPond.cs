using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*THE RIGIDBODY OF THE PLAYER MUST BE SET TO NEVER SLEEP or else this won't work
-this script goes on the POND
*/

public class FishAtPond : MonoBehaviour
{

    [SerializeField]
    private string interactButton;//name of button we press to fish as set up on input axis

    private Slider slider;
    private ImageActive iconScript;
    private PlayerStateManager stateManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovePlayer>() != null)//if the collision has a player only script
        {
            iconScript = collision.gameObject.GetComponentInChildren<ImageActive>();//this is set active false so need to color change
            iconScript.TurnImageOn();

            slider = collision.gameObject.GetComponentInChildren<Slider>();

            slider.value = 0;
            slider.GetComponent<SliderManager>().TurnNormalColor();    
        }
        collision.gameObject.GetComponent<PlayerStateManager>().canDropFish = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovePlayer>() != null)//if the collision has a player only script
        {
            stateManager = collision.gameObject.GetComponent<PlayerStateManager>();
            updateSliderBasedOnButtons(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        slider = collision.gameObject.GetComponentInChildren<Slider>();


        slider.value = 0;
        slider.gameObject.GetComponent<SliderManager>().TurnNormalColor();

        collision.GetComponentInChildren<ImageActive>().TurnImageOff();//this is how we hide the icon
        collision.gameObject.GetComponent<PlayerStateManager>().canDropFish = true;
    }

    void updateSliderBasedOnButtons(Collider2D collision)
    {
        slider = collision.gameObject.GetComponentInChildren<Slider>();

        if (Input.GetButton(interactButton))
        {
            if (slider.value < slider.maxValue)
            {
                stateManager.PlayerState = PlayerStateManager.State.fishing;
                slider.value++;
            }
            else if (slider.value >= slider.maxValue)
            {
                slider.GetComponentInChildren<Image>().color = Color.green;

                if (!stateManager.playerHasFish)//if we don't have a fish, we do now
                    stateManager.playerHasFish = true;

                StartCoroutine(CanDropFishBuffer());
            }
        }

        else
        {
            slider.value = slider.minValue;
            slider.GetComponentInChildren<Image>().color = Color.white;
        }
    }

    IEnumerator CanDropFishBuffer()
    {
        yield return new WaitForSeconds(1);
        stateManager.canDropFish = true;
    }
}
