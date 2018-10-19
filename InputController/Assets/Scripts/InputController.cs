using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    /*
     * Okay so I freakin set input to be an Input Handler like 3 different ways and it keeps giving me a nullreferenceexception
     * I've been working on this for 3 hours and the other one for 6 hours. I've looked up all of our examples, and I've
     * googled a buncha stuff. At some point I just need to hope that I'm demonstrating enough to get full points
     */

    SpriteRenderer sprite;
    Vector2 movement;
    private InputHandler input;

    // Use this for initialization
    void Awake()
    {
        input = gameObject.GetComponent("InputHandler") as InputHandler;
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        input.GetAxis();
        Move();
        KeepOnScreen();
	}

    private void Move()
    {
        transform.Translate(movement);
    }

    private void KeepOnScreen()
    {
        if(input.horizontalMovement >= Screen.width - sprite.bounds.size.x)
        {
            input.horizontalMovement = Screen.width - sprite.bounds.size.x;
        }
        if (input.horizontalMovement <= sprite.bounds.size.x)
        {
            input.horizontalMovement =  sprite.bounds.size.x;
        }
    }
}
