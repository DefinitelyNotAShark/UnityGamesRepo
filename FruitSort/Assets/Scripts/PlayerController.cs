using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector2 direction = new Vector2(); //direction the will influence player
    public Vector2 keyDirection;

    public bool ConstrainVertical;

    public bool IsKeyDown   //Boolean the lets player know is a key is down usefull to stop player if no keys are pressed
    {
        get
        {
            if (keyDirection.sqrMagnitude == 0) return false;
            return true;
        }
    }

    public PlayerController()
    {

    }

    void Awake()
    {
        keyDirection = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {

        //Get Keys From Input Directly
        keyDirection.x = keyDirection.y = 0;

        //Keyboard
        if (Input.GetKey("right"))
        {
            keyDirection.x += 1;
        }
        if (Input.GetKey("left"))
        {
            keyDirection.x += -1;
        }

        if (!ConstrainVertical)
        {
            if (Input.GetKey("up"))
            {
                keyDirection.y += 1;
            }
            if (Input.GetKey("down"))
            {
                keyDirection.y += -1;
            }
        }

        direction += keyDirection;
        direction.Normalize();  //Normalize
    }
}
