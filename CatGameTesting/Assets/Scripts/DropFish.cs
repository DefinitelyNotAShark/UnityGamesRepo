using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//THIS GOES ON THE PLAYER
public class DropFish : MonoBehaviour
{
    //check if we have a fish and then if we're dropping it. Can't drop a fish if anything else is happening
    private PlayerStateManager stateManager;

    [SerializeField]
    private GameObject fishPrefab;

    [SerializeField]
    private string interactButton;

    private GameObject fishInstance;

	void Start ()
    {
        stateManager = GetComponent<PlayerStateManager>();	
	}
	
	void Update ()
    {
		if(stateManager.playerHasFish && stateManager.canDropFish)
        {
            if(Input.GetAxis(interactButton) > 0)
            {
                //instantiate fish prefab
                //add the detect fish collision
                fishInstance = Instantiate(fishPrefab);
                stateManager.playerHasFish = false;
            }
        }
	}
}
