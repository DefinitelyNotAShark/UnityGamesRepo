using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public float horizontalMovement;
    public float verticalMovement;

    private string horizontalAxisName = "Horizontal";
    private string verticalAxisName = "Vertical";

    public static Vector2 movement;

    private void Start()
    {
        movement = new Vector2(horizontalMovement, verticalMovement);
    }

    public void GetAxis()
    {
        horizontalMovement = Input.GetAxis(horizontalAxisName);
        verticalMovement = Input.GetAxis(verticalAxisName);
    }
}
