using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    private string horizontalAxisName;

    [SerializeField]
    private float maxPosX;

    [SerializeField]
    private float minPosX;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private Text debugText;

    [SerializeField]
    private float moveForwardSpeed;

    private float horizontalAxisValue;

	void Update ()
    {
        GetInput();
        MoveForward();
	}

    private void MoveForward()
    {
        transform.Translate(0, 0, moveForwardSpeed * Time.deltaTime);//should only move x and z. Why does it move y?
    }

    private void FixedUpdate()
    {
        if (canMove())
            Move();
    }

    private void GetInput()
    {
         horizontalAxisValue = Input.GetAxis(horizontalAxisName);
    }

    private bool canMove()
    {
        if (horizontalAxisValue > 0 && transform.position.x >= maxPosX)//if we're at our right wall and we're trying to go right
        {
            return false;
        }
        else if (horizontalAxisValue < 0 && transform.position.x <= minPosX)
        {
            return false;
        }
        else return true;
    }

    private void Move()
    {
        Vector3 moveVector = new Vector3(horizontalAxisValue * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(moveVector);
        transform.Rotate(moveVector * rotateSpeed);
        debugText.text = "PositionX = " + transform.position.x.ToString();
    }
}
