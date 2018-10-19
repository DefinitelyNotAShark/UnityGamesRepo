using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I put this in because I had time and because it might make things easier to animate.
//Unity recognizes when the player is idle, running, jumping, or falling
public class PlayerStateManager : MonoBehaviour
{
    public enum State//possible states the player could be in
    {
        idle,
        running,
        jumping,
        falling,
        fishing,
        pickingUpFish,
        holdingFishIdle,
        holdingFishRunning,
        holdingFishJumping,
        holdingFishFalling,
        slappingWithFish,
        droppingFish,//these 2 probably don't need to be animations
        throwingFish,//these 2 probably don't need to be animations
        beingSlappedByFish
    }

    [HideInInspector]
    public State PlayerState;

    [HideInInspector]
    public bool playerHasFish = false;

    [HideInInspector]
    public bool canDropFish = true;

	// Use this for initialization
	void Start ()
    {
        PlayerState = State.idle;
	}

    private void Update()
    {
        if (playerHasFish == false)
            canDropFish = false;
    }
}
